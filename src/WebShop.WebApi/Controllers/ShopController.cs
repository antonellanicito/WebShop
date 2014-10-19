using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Model;
using WebShop.Providers;
using WebShop.Providers.Contracts;
using WebShop.Builders;
using WebShop.Builders.Contracts;
namespace WebShop.WebApi.Controllers
{
    public class ShopController : Controller
    {
        readonly IArticleBuilder articleBuilder;
        readonly IXmlProvider xmlProvider;

        public ShopController(IArticleBuilder s_articleBuilder, IXmlProvider s_xmlProvider)
        {
            articleBuilder = s_articleBuilder;
            xmlProvider = s_xmlProvider;
        }

        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ListArticles()
        {
            List<Article> model = articleBuilder.GetArticles(xmlProvider.GetXmlArticles());
            return PartialView(model);


        }
        public PartialViewResult ShoppingCart()
        {
            Customer current = new Customer();
            if (HttpContext.Session["customer"] == null)

                Session["customer"] = current;

            else
                current = (Customer)Session["customer"];
            
            return PartialView(current.ShoppingCart);
        }
        public PartialViewResult Add(int id)
        {
            Customer current = (Customer) Session["customer"];
            current.AddArticle(articleBuilder.GetArticlesById(xmlProvider.GetXmlArticles(),id));
            return PartialView("ShoppingCart", current.ShoppingCart);
        }
        public PartialViewResult Remove(int id)
        {
            Customer current = (Customer)Session["customer"];
            current.RemoveArticle(id);
            return PartialView("ShoppingCart", current.ShoppingCart);
        }

        public ActionResult Complete()
        { 
            return View();

        }
    }

}