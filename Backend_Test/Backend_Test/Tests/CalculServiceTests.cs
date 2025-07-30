using Backend_Test.Models;
using Backend_Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xunit;


namespace Backend_Test.Tests
{
    public class CalculServiceTests
    {
        [Fact]
        public void Calculer_RetourneResultatCorrect()
        {
            var input = new RequeteCalcul
            {
                MontantAchat = 120000,
                FondsPropres = 20000,
                DureeMois = 240,
                TauxAnnuel = 2.4m
            };

            var sut = new CalculService();
            var result = sut.Calculer(input);

          
            Assert.Equal(112000m, result.MontantEmprunteBrut); 
            Assert.Equal(2240m, result.FraisHypotheque); 
            Assert.Equal(114240m, result.MontantEmprunteNet);
            Assert.Equal(0.198m, result.TauxMensuel); 
            Assert.Equal(598.48m, result.Mensualite); 
            Assert.Equal(240, result.Amortissement.Count);
            Assert.Equal(0m, result.Amortissement[239].SoldeFin); 
        }

    
}
}