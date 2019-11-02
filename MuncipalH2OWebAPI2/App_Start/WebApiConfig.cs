using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MuncipalH2OWebAPI2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
         config.EnableCors();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);



         //config.Routes.MapHttpRoute(
         //    name: "DefaultApi2",
         //    routeTemplate: "api/{controller}/{rwhsStatus}",
         //    defaults: new { rwhsStatus = RouteParameter.Optional }
         //    );
        }
    }
}
