using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using WebShop.Providers;
using WebShop.Providers.Contracts;
using WebShop.Builders;
using WebShop.Builders.Contracts;
using WebShop.Model;
using System.Xml.Linq;
using Microsoft.Practices.ServiceLocation;
namespace WebShop.WebApi.Controllers
{
    public class ArticleController : ApiController
    {
        readonly IArticleBuilder articleBuilder;
        readonly IXmlProvider xmlProvider;

        public ArticleController(IArticleBuilder s_articleBuilder, IXmlProvider s_xmlProvider)
        {
            //var pippo = ServiceLocator.Current.GetService(typeof(IXmlProvider));
            articleBuilder = s_articleBuilder;
            xmlProvider = s_xmlProvider;
        }
        [HttpGet]
        public Article GetArticleById(int id)
        {
            try
            {
                Article result = articleBuilder.GetArticlesById(xmlProvider.GetXmlArticles(), id);
                return result;
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent("No Article found") };
                throw new HttpResponseException(response);
               
            }
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