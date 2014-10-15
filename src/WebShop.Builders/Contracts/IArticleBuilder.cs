using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShop.Model;
using System.Xml.Linq;
using WebShop.Builders;

namespace WebShop.Builders.Contracts
{
    public interface IArticleBuilder 
    {
        List<Article> GetArticles(XDocument XDoc);
        Article GetArticlesById(XDocument XDoc, int IdArticle);
    }
}
