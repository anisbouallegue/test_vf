using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Backend_Test.Models
{
    public class RequeteCalcul
    {

        public decimal MontantAchat { get; set; }
        public decimal FondsPropres { get; set; }
        public int DureeMois { get; set; }
        public decimal TauxAnnuel { get; set; }
        public bool fraisManuels { get; set; }
        public decimal? FraisAchat { get; set; }
        public decimal? MontantEmprunter { get; set; }
    }
}