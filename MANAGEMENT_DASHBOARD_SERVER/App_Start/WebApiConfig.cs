using MANAGEMENT_DASHBOARD_SERVER.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MANAGEMENT_DASHBOARD_SERVER
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new JwtAuthHandler("jkjdlLKHKDlkd226#^&#*@(#(@NDKWDJjksdsfssd556412sflkslkJHDDKEjl#*$($GHD"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
