using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShop.DAL.Contracts;
using WebShop.Model;
namespace WebShop.DAL
{
    public class BLL :IBLL
    {
        readonly WebShopContext webShopContext; 
        public BLL()
        {
            webShopContext = new WebShopContext(false);
        }
        
        public List<Title> GetTitles()
        {
            WebShopContext webShopContext = new WebShopContext(false);
            return webShopContext.Titles.Select(c => (Title)c).ToList();
        }

        public Customer LoginCustomer(string email)
        {
            if (webShopContext.Customers.Any(c => c.Email.ToLower().Equals(email.ToLower())))
            {
                return (Customer)webShopContext.Customers.Single(c => c.Email.ToLower().Equals(email.ToLower()));
                
            }
            return null;


        }

        public Customer RegisterCustomer(Customer customer)
        {
            try
            {
                if (!webShopContext.Customers.Any(c => c.Email.ToLower().Equals(customer.Email.ToLower())))
                webShopContext.Customers.Add(customer);
                webShopContext.SaveChanges();
                  
                return customer;
            }
            catch
            {
                return null;
            }

            
        }


        public bool InsertOrder(Enquiry enquiry)
        {
            OrderDetail detail;
            Order order = new Order();
            try
            {
                order.DateOrder = DateTime.Now;

                order.Customer = enquiry.customer;
                foreach (KeyValuePair<Article, int> item in enquiry.ShoppingCart)
                {

                    detail = new OrderDetail();
                    detail.ArticleID = item.Key.ArticleID;
                    detail.Order = order;
                    detail.Qty = item.Value;

                    webShopContext.OrderDetails.Add(detail);
                    
                }
                webShopContext.Orders.Add(order);
                webShopContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
