using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Backend_Test
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // Ajoutez ici vos filtres globaux
            filters.Add(new HandleErrorAttribute()); // Gestion des erreurs par défaut

            // Exemple : forcer le HTTPS en production
            // filters.Add(new RequireHttpsAttribute()); 
        }
    }
}