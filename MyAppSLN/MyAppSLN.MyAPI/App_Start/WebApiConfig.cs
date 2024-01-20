using MyAppSLN.MyAPI.Router;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MyAppSLN.MyAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {            
            //---------------------------------------------------------------------------------------------
            // Web API configuration and services
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            //To Remove Self Reference Loop For All Models instead Of [JsonIgnore]
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.Filters.Add(new BasicAuthenticationAttribute());
            //---------------------------------------------------------------------------------------------
            // Web API configuration and services

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
