using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend_Test.Models
{
    public class ResultatCalcul
    {
        public decimal MontantAchat { get; set; }
        public decimal FondsPropres { get; set; }
        public decimal FraisAchat { get; set; }
        public decimal MontantEmprunteBrut { get; set; }
        public decimal FraisHypotheque { get; set; }
        public decimal MontantEmprunteNet { get; set; }
        public decimal TauxMensuel { get; set; }
        public decimal Mensualite { get; set; }
        public List<LigneAmortissement> Amortissement { get; set; }
    }
}