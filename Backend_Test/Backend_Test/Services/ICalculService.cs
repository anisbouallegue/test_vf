using Backend_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend_Test.Services
{
    public interface ICalculService
    {
        ResultatCalcul Calculer(RequeteCalcul req);
    }
}