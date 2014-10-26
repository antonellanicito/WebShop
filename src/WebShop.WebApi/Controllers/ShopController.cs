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
using WebShop.DAL;
using WebShop.DAL.Contracts;
namespace WebShop.WebApi.Controllers
{
    public class ShopController : Controller
    {
        readonly IArticleBuilder articleBuilder;
        readonly IXmlProvider xmlProvider;
        readonly IEntityRepository entityHandler;

        public ShopController(IArticleBuilder s_articleBuilder, IXmlProvider s_xmlProvider, IEntityRepository s_entityHandler)
        {
            articleBuilder = s_articleBuilder;
            xmlProvider = s_xmlProvider;
            entityHandler = s_entityHandler;
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
            Enquiry current = new Enquiry();
            if (HttpContext.Session["enquiry"] == null)

                Session["enquiry"] = current;

            else
                current = (Enquiry)Session["enquiry"];
            
            return PartialView(current.ShoppingCart);
        }
        public PartialViewResult Add(int id)
        {
            Enquiry current = (Enquiry)Session["enquiry"];
            current.AddArticle(articleBuilder.GetArticlesById(xmlProvider.GetXmlArticles(),id));
            return PartialView("ShoppingCart", current.ShoppingCart);
        }
        public PartialViewResult Remove(int id)
        {
            Enquiry current = (Enquiry)Session["enquiry"];
            current.RemoveArticle(id);
            return PartialView("ShoppingCart", current.ShoppingCart);
        }

        public ActionResult Complete(Customer model)
        {
            bool completed = false;

            Enquiry enquiry = (Enquiry)Session["enquiry"];
            
            if (Request.HttpMethod == "POST")
            {
                Customer customer;
                if (Request.Form.AllKeys.Contains("handler") && Request.Form.GetValues("handler")[0].Equals("Login"))
                {
                    customer = entityHandler.LoginCustomer(model.Email);

                    if (customer != null)
                    {
                        //manage shoppingCart
                        enquiry.customer = customer;
                        completed = entityHandler.InsertOrder(enquiry);
                    }
                }
                else
                {
                    customer = entityHandler.RegisterCustomer(model);
                    if (customer != null)
                    {
                        //manage shoppingCart
                        enquiry.customer = customer;
                        completed = entityHandler.InsertOrder(enquiry);
                    }
                }

                if (completed)
                   enquiry.EmptyShoppingCart();
                ViewBag.Completed = completed;
            }
 
            return View(model);
        }
    }

}