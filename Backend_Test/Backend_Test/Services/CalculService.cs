using Backend_Test.Models;
using System;
using System.Collections.Generic;

namespace Backend_Test.Services
{
    public class CalculService : ICalculService
    {
        public ResultatCalcul Calculer(RequeteCalcul requete)
        {
            //frais d'achat ==> 10% du montant de l'achat au dessus de 50 000
            //possibilité de modifier les frais d'achat manuellement.	
            decimal fraisAchat = requete.fraisManuels && requete.FraisAchat.HasValue
                ? requete.FraisAchat.Value
                : (requete.MontantAchat > 50000 ? requete.MontantAchat * 0.10m : 0);


            // possibilité de modifier le montant à emprunter et de calculer le montant des fonds propre pour
            // conserver le montant de l'achat
            if (requete.MontantEmprunter.HasValue)
            {
                decimal nouveauFondsPropres = requete.MontantAchat + fraisAchat - requete.MontantEmprunter.Value;
                requete.FondsPropres = Math.Max(nouveauFondsPropres, 0);
            }

            //Montant à emprunter brut
            decimal montantBrut = requete.MontantAchat + fraisAchat - requete.FondsPropres;

            //Frais d'hypothèque (2%)
            decimal fraisHypotheque = Math.Round(montantBrut * 0.02m, 2);

            //Montant net à emprunter
            decimal montantNet = montantBrut + fraisHypotheque;

            //Taux mensuel
            decimal tauxMensuel = TauxMensuel(requete.TauxAnnuel);

            //Mensualité
            decimal mensualite = Mensualite(montantNet, tauxMensuel, requete.DureeMois);

            //Tableau d'amortissement
            var amortissement = Amortissement(montantNet, mensualite, tauxMensuel, requete.DureeMois);

            return new ResultatCalcul
            {
                MontantAchat = requete.MontantAchat,
                FondsPropres = requete.FondsPropres,
                FraisAchat = fraisAchat,
                MontantEmprunteBrut = montantBrut,
                FraisHypotheque = fraisHypotheque,
                MontantEmprunteNet = montantNet,
                TauxMensuel = tauxMensuel,
                Mensualite = mensualite,
                Amortissement = amortissement
            };
        }
        private decimal TauxMensuel(decimal tauxAnnuel)
        {
            double tauxDecimal = (double)tauxAnnuel / 100;
            double tauxMensuel = Math.Pow(1 + tauxDecimal, 1.0 / 12) - 1;
            return Math.Round((decimal)tauxMensuel * 100, 3);
        }

        private decimal Mensualite(decimal capital, decimal tauxMensuel, int dureeMois)
        {
            decimal tauxDecimal = tauxMensuel / 100;
            decimal facteur = (decimal)Math.Pow(1 + (double)tauxDecimal, dureeMois);
            return Math.Round(capital * tauxDecimal * facteur / (facteur - 1), 2);
        }

        private List<LigneAmortissement> Amortissement(decimal capital, decimal mensualite, decimal tauxMensuel, int dureeMois)
        {
            var tableau = new List<LigneAmortissement>();

            decimal solde = capital;
            decimal taux = tauxMensuel / 100;

            for (int mois = 1; mois <= dureeMois; mois++)
            {
                decimal interets = Math.Round(solde * taux, 2);

                decimal capitalRembourse = mensualite - interets;
                solde -= capitalRembourse;

                //pour la dernière ligne, faire que le capital de fin soit tjrs 0 (en ajustant la colonne intérêt) 
            
                if (mois == dureeMois)
                {
                    capitalRembourse += solde;
                    solde = 0;
                }

                tableau.Add(new LigneAmortissement
                {
                    Periode = mois,
                    SoldeDebut = solde + capitalRembourse,
                    Interets = interets,
                    CapitalRembourse = capitalRembourse,
                    SoldeFin = solde
                });
            }

            return tableau;
        }
    }
}