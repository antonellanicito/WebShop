using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebShop.Model;
using WebShop.Providers;
using WebShop.Providers.Contracts;
using WebShop.Builders;
using WebShop.Builders.Contracts;

namespace WebShop.DAL
{
    public class WebShopContext : DbContext
    {        
        
        public DbSet<Article> Articles { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public WebShopContext(bool firstLoad)
            : base("LocalWebShop")
        {
            if (firstLoad)
            {
                Database.SetInitializer<WebShopContext>(new DBInitializer());
                this.Database.Initialize(false);
            }
        }
    }
    public class DBInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WebShopContext>
    {
        public IArticleBuilder articleBuilder;
        public IXmlProvider xmlProvider;

        protected override void Seed(WebShopContext context)
        {
            context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IX_Customer_Email ON Customer (Email)");
            articleBuilder = new ArticleBuilder();
            xmlProvider = new XmlProvider();

            List<Title> titles = new List<Title>
            {
                new Title  {TitleID=1,TitleDescription="Miss"},
                new Title  {TitleID=2,TitleDescription="Mrs"},
                new Title  {TitleID=3,TitleDescription="Mister"}
            };

            context.Titles.AddRange(titles);

            List<Article> articles = articleBuilder.GetArticles(xmlProvider.GetXmlArticles());

            context.Articles.AddRange(articles);

            context.SaveChanges();
        }
    }
}

