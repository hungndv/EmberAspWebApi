using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using JSONAPI.Json;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Microsoft.Practices.Unity;
using Demo.Bll.Interfaces;
using Demo.Dal;
using Demo.Dal.Implements;

namespace Demo.Bll.WebApi
{
    public static class WebApiConfig
    {
        private static void InitIoc(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IStudentRepository, StudentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IStudentService, StudentService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }

        public static void Register(HttpConfiguration config)
        {
            InitIoc(config);

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/vnd.api+json"));

            // Use camel case for JSON data.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
