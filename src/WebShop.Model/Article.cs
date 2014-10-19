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
        public decimal TotalPrice
        {
            get { return Price + (Price * VATRate / 100); }
        }

        public string FormattedPrice
        {
            get { return String.Format("{0:0.00}", Price); }
        }

        public string FormattedVAT
        {
            get { return String.Format("{0:0.00}", VATRate); }
        }
        public string FormattedTotalPrice
        {
            get { return String.Format("{0:0.00}", Price + (Price*VATRate/100)); }
        }

    }
}
