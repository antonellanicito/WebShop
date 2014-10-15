using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShop.Providers.Contracts;
using System.Xml.Linq;
using System.Web;
using System.Configuration; 
namespace WebShop.Providers
{
    public class XmlProvider : IXmlProvider
    {
        public XDocument GetXmlArticles()
        {
            try
            {
                string uri = ConfigurationManager.AppSettings["XmlFileArticlesPath"];
                return XDocument.Load(HttpContext.Current.Request.PhysicalApplicationPath + uri);
            }

            catch 
            {
                return XDocument.Parse("<document><Articles></Articles></document>");
            }
        }
    }
}
