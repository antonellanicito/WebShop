using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShop.Providers.Contracts;
using System.Xml.Linq;
using System.Web;
using System.Configuration;
using System.Web.Caching;


namespace WebShop.Providers
{
    public class XmlProvider : IXmlProvider
    {
        public XDocument GetXmlArticles()
        {
            XDocument xmlArticles = new XDocument();
            try
            {


                if (HttpContext.Current.Cache.Get("key_XMLArticle") == null)
                {
                    string uri = ConfigurationManager.AppSettings["XmlFileArticlesPath"];
                    xmlArticles = XDocument.Load(HttpContext.Current.Request.PhysicalApplicationPath + uri);

                    HttpContext.Current.Cache.Insert("key_XMLArticle", xmlArticles);
                }
                else
                    xmlArticles = (XDocument) HttpContext.Current.Cache.Get("key_XMLArticle");

                return xmlArticles;
            }

            catch 
            {
                return XDocument.Parse("<document><Articles></Articles></document>");
            }
        }
        
              
    }
}
