using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShop.Model;

namespace WebShop.DAL.Contracts
{
    public interface IEntityRepository
    {
        bool InsertOrder(Enquiry enquiry);
        Customer LoginCustomer(string email);
        Customer RegisterCustomer(Customer customer);
        List<Title> GetTitles();
    }
}
