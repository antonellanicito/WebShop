using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net;
using System.Web.Http;

using WebShop.Providers;
using WebShop.Providers.Contracts;
using WebShop.Builders;
using WebShop.Builders.Contracts;
using WebShop.Model;
using System.Xml.Linq;
namespace WebShop.WebApi.Controllers
{
    public class ArticleController : ApiController
    {
        readonly IArticleBuilder articleBuilder;
        readonly IXmlProvider xmlProvider;

        public ArticleController(IArticleBuilder s_articleBuilder, IXmlProvider s_xmlProvider)
        {
            articleBuilder = s_articleBuilder;
            xmlProvider = s_xmlProvider;
        }
        public Article GetArticleById(int id)
        {
            return articleBuilder.GetArticlesById(xmlProvider.GetXmlArticles(),id);
        }

        [HttpGet]
        public  List<Article> GetArticles() 
        {
           
            try
            {
                return articleBuilder.GetArticles(xmlProvider.GetXmlArticles());
            }
            catch
            { return new List<Article>(); }
            
        }

    }
}