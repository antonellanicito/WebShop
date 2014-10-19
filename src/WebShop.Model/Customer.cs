using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebShop.Model
{
    public class Customer : MasterData
    {
        //articles details
        private List<Article> shoppingCartDetails;
        //key = idArticle, int = number of articles with same id
        private Dictionary<int, int> shoppingCart;
        public Customer() {
            shoppingCartDetails = new List<Article>();
            shoppingCart = new Dictionary<int, int>();
        }

        
        public void AddArticle(Article article)
        {
            if (shoppingCart.ContainsKey(article.Id))
                shoppingCart[article.Id]++;
            else
            {
                shoppingCart.Add(article.Id, 1);
                shoppingCartDetails.Add(article);
            }
    
        }
        public void RemoveArticle(int IdArticle)
        {
            if (shoppingCart[IdArticle].Equals(1))
            {
                shoppingCart.Remove(IdArticle);
                shoppingCartDetails.RemoveAll(c => c.Id.Equals(IdArticle));
            }
            else
                shoppingCart[IdArticle]--;
        }

        public List<KeyValuePair<Article, int>> ShoppingCart
        {
            get
            {
                return shoppingCart.Select(c => new KeyValuePair<Article, int>(shoppingCartDetails.Single(d=>d.Id.Equals(c.Key)),c.Value) )  .ToList();
            }
        }
    }
}
