using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Model;
using WebShop.DAL;
using WebShop.DAL.Contracts;

namespace WebShop.WebApi.Controllers
{
    public class CustomerController : Controller
    {
        readonly IBLL bLL;
        public CustomerController(IBLL s_bLL) {
            bLL = s_bLL;
        }
        public ActionResult Login(Customer model)
        {
            ViewBag.IsNewUser = false;           
           
            if (Request.HttpMethod == "GET")
            
                ModelState.Clear();
            
           

            return PartialView("MasterData", model);
        }
        public ActionResult Register(Customer model)
        {
            ViewBag.Titles = new SelectList(bLL.GetTitles(), "TitleID", "TitleDescription");
            ViewBag.IsNewUser = true;
            if (Request.HttpMethod == "GET")

                ModelState.Clear();


            return PartialView("MasterData", model);
        }
    }
}
