using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebShop.Model
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal VATRate { get; set; }



    }
}
