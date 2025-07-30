using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend_Test.Models
{
    public class LigneAmortissement
    {
        public int Periode { get; set; }
        public decimal SoldeDebut { get; set; }
        public decimal Interets { get; set; }
        public decimal CapitalRembourse { get; set; }
        public decimal SoldeFin { get; set; }
    }
}