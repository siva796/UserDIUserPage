using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Net.Http.Formatting;
using Unity;
using Carousel.BusinessLogicData.Interfaces;
using Carousel.BusinessLogicData.BusinessLogic;
using Unity.Lifetime;


namespace WebApiCarousel
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var container = new UnityContainer();
            container.RegisterType<IBusinessLogic,UserBal >(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            container.AddNewExtension<UnityExtension>();

        }
    }

   
}
