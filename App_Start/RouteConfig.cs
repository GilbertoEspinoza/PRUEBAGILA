﻿using System.Web.Mvc;
using System.Web.Routing;

namespace PRUEBAGILA
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{opt}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional, opt = UrlParameter.Optional }
            );
        }
    }
}
