export interface RequeteCalcul {
  montantAchat: number;
  fondsPropres: number;
  dureeMois: number;
  tauxAnnuel: number;
  fraisManuels: boolean;
  fraisAchat?: number;
}

export interface ResultatCalcul{
  montantEmprunteBrut: number;
  fraisHypotheque: number;
  montantEmprunteNet: number;
  tauxMensuel: number;
  mensualite: number;
  amortissement: LigneAmortissement[];
}

export interface LigneAmortissement {
  periode: number;
  soldeDebut: number;
  interets: number;
  capitalRembourse: number;
  soldeFin: number;
}