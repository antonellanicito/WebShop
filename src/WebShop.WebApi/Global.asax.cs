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
using System.Configuration;
using WebShop.DAL;

using System.Data.Entity;
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

            WebShopContext context = new WebShopContext(true);
            //Database.SetInitializer(new CreateDatabaseIfNotExists<WebShopDBContext>());

            //using (var db = new WebShopDBContext())
            //{
            //    db.Database.Initialize(false);

            //}
            //InitLocalDb();
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

        //private static void InitLocalDb()
        //{
        //    var ee = new System.Data.EntityClient.EntityConnectionStringBuilder();
        //    var builder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["DbLocalEntities"].ConnectionString);

        //    using (var connection = new SQLiteConnection(builder.ProviderConnectionString))
        //    using (var command = connection.CreateCommand())
        //    {

        //        connection.Open(); //Automatically creates sqlite datbase if none exists
        //        var titles = connection.GetSchema("Tables").Select("Table_Name = 'Titles'");
        //        if (titles.Length <= 0)
        //        { 
        //            command.CommandText = 
        //            "CREATE TABLE [Titles] (" +
        //            "[IdTitle] INTEGER PRIMARY KEY NOT NULL," + 
        //            "[Title] TEXT NOT NULL" +
        //            ")";

        //            command.ExecuteNonQuery();

        //            command.CommandText =
        //            "INSERT INTO Titles " +
        //            "(IdTitle, Title) " +
        //            "VALUES (1, 'Mr')";
        //            command.ExecuteNonQuery();

        //            command.CommandText =
        //            "INSERT INTO Titles " +
        //            "(IdTitle, Title) " +
        //            "VALUES (2, 'Miss')";
        //            command.ExecuteNonQuery();

        //            command.CommandText =
        //            "INSERT INTO Titles " +
        //            "(IdTitle, Title) " +
        //            "VALUES (3, 'Mrs')";
        //            command.ExecuteNonQuery();
        //        }


        //        var table = connection.GetSchema("Tables").Select("Table_Name = 'Customers'");
        //        if (table.Length <= 0)
        //        {
        //            command.CommandText =
        //                "CREATE TABLE [Customers] ( " +
        //                "[IdCustomer] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, " +
        //                "[IdTitle] INTEGER NOT NULL REFERENCES Titles(IdTitle), " + 
        //                "[FirstName] TEXT NOT NULL, " + 
        //                "[LastName] TEXT NOT NULL, " +
        //                "[Address] TEXT NOT NULL, " +
        //                "[HouseNumber] TEXT NOT NULL, " +
        //                "[ZipCode] TEXT NOT NULL, " +
        //                "[City] TEXT NOT NULL, " +
        //                "[Email] TEXT UNIQUE NOT NULL " + 
        //                ")";
        //            command.ExecuteNonQuery();

        //        }

        //        var article = connection.GetSchema("Tables").Select("Table_Name = 'Articles'");
        //        if (table.Length <= 0)
        //        {
        //            command.CommandText =
        //                "CREATE TABLE [Articles] ( " +
        //                "[IdArticle] INTEGER PRIMARY KEY NOT NULL, " +
        //                "[Name] TEXT NOT NULL, " +
        //                "[Summary] TEXT NOT NULL, " +
        //                "[Description] TEXT NOT NULL, " +
        //                "[Price] NUMERIC NOT NULL, " +
        //                "[VAT] NUMERIC NOT NULL " +

        //                ")";
        //            command.ExecuteNonQuery();

        //        }

        //        var orders = connection.GetSchema("Tables").Select("Table_Name = 'Orders'");
        //        if (table.Length <= 0)
        //        {
        //            command.CommandText =
        //                "CREATE TABLE [Orders] ( " +
        //                "[IdOrder] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, " +
        //                "[DateOrder] NUMERIC NOT NULL, " +
        //                "[IdCustomer] INTEGER NOT NULL REFERENCES Customers(IdCustomer) " +

        //                ")";
        //            command.ExecuteNonQuery();

        //        }
        //        var relorders = connection.GetSchema("Tables").Select("Table_Name = 'Rel_OrdersArticles'");
        //        if (table.Length <= 0)
        //        {
        //            command.CommandText =
        //                "CREATE TABLE [Rel_OrdersArticles] ( " +
        //                "[IdOrder] INTEGER NOT NULL REFERENCES Orders(IdOrder), " +
        //                "[IdArticle] INTEGER NOT NULL REFERENCES Articles(IdArticle), " +
        //                "[ItemsNr] INTEGER NOT NULL, " +
        //                "PRIMARY KEY (IdOrder, IdArticle)" + 
        //                ")";
        //            command.ExecuteNonQuery();

        //        }
        //        //var uriIndex = connection.GetSchema("Indexes").Select("Index_Name = 'IDX_BINARIES_COMPONENTURI'");
        //        //if (uriIndex.Length <= 0)
        //        //{
        //        //    command.CommandText =
        //        //        "CREATE INDEX [IDX_BINARIES_COMPONENTURI] ON [Binaries](" +
        //        //        "[ComponentUri]  DESC" +
        //        //        ")";
        //        //    command.ExecuteNonQuery();
        //        //}

        //        //var pathIndex = connection.GetSchema("Indexes").Select("Index_Name = 'IDX_BINARIES_PATH'");
        //        //if (pathIndex.Length <= 0)
        //        //{
        //        //    command.CommandText =
        //        //        "CREATE INDEX [IDX_BINARIES_PATH] ON [Binaries](" +
        //        //        "[Path]  DESC" +
        //        //        ")";
        //        //    command.ExecuteNonQuery();
        //        //}
        //    }
        //}
    }




}