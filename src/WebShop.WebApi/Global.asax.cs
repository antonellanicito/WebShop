using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebShop.Builders;
using WebShop.Builders.Contracts;
using Microsoft.Practices.Unity;

namespace WebShop.WebApi
{
    // Nota: per istruzioni su come abilitare la modalità classica di IIS6 o IIS7, 
    // visitare il sito Web all'indirizzo http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver();
            Register(GlobalConfiguration.Configuration);

            Bootstrapper.Initialise();           
        }
        public static void Register(HttpConfiguration config)
        {
            //config.Routes.MapHttpRoute(
            //     name: "ApiById",
            //     routeTemplate: "api/{controller}/{id}",
            //     defaults: new { id = RouteParameter.Optional },
            //     constraints: new { id = @"^[0-9]+$" }
            // );

            //config.Routes.MapHttpRoute(
            //    name: "ApiByName",
            //    routeTemplate: "api/{controller}/{action}/{name}",
            //    defaults: null,
            //    constraints: new { name = @"^[a-z]+$" }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "ApiByAction",
            //    routeTemplate: "api/{controller}/{action}",
            //    defaults: new { action = "GetArticles" }
            //);



            //config.Routes.MapHttpRoute(
            //    name: "test1",
            //    routeTemplate: "api/Article/{id}",
            //    defaults: new
            //    {
            //        controller = "Article",
            //        action = "GetArticleById",
            //        id = UrlParameter.Optional
            //    });


            //config.Routes.MapHttpRoute(
            //    name: "test2",
            //    routeTemplate: "api/Article/All/",
            //    defaults: new
            //    {
            //        controller = "Article",
            //        action = "GetArticles",
                    
            //    });

        }
    }

            //    routes.MapRoute(
            //    "Destination",
            //    "{language}/destinations/{code}",
            //    new { controller = "Destination", action = "Index" }, // Parameter defaults
            //    new { httpMethod = new HttpMethodConstraint("GET") } // Parameter constraints
            //);


}