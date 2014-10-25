using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShop.Builders.Contracts;
using WebShop.Model;
using System.Xml.Linq;
namespace WebShop.Builders
{
    public class ArticleBuilder : IArticleBuilder
    {
        public List<Article> GetArticles(XDocument XDoc)
        {
            return getArticles(XDoc);
        }
        public Article GetArticlesById(XDocument XDoc, int IdArticle)
        {
            return getArticles(XDoc).First(c => c.ArticleID.Equals(IdArticle));
        }

        private List<Article> getArticles(XDocument XDoc)
        {
            return XDoc.Descendants("Article")
                .Where(c => c.Attribute("key") != null)
                .Where(c => c.Descendants("Price").Any())
                .Where(c => c.Descendants("VAT").Any())
                .Select(c => new Article
                {
                    ArticleID = int.Parse(c.Attribute("key").Value),
                    Name = c.Element("Name") != null ? c.Element("Name").Value : "",
                    Description = c.Element("Description") != null ? c.Element("Description").Value : "",
                    Summary = c.Element("Summary") != null ? c.Element("Summary").Value : "",
                    Price = decimal.Parse(c.Element("Price").Value),
                    VATRate = decimal.Parse(c.Element("VAT").Value)
                }).ToList();
        }
        
    }
}
