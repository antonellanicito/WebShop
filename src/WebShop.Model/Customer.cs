using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace WebShop.Model
{

    [Table("Customer")]
    public class Customer 
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        [StringLength(100)]
        public string HouseNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string ZipCode { get; set; }
        [Required]
        [StringLength(100)]
        public string City { get; set; }
        [Required]
        [StringLength(100)]
        [RegularExpression(@"^[a-z._-]+\@[a-z._-]+\.[a-z]{2,4}$", ErrorMessage="Insert valid Email")]
        
        public string Email { get; set; }


        [Required]
        public int TitleID { get; set; }

        public virtual Title Title { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
    [NotMapped]
    public class Enquiry

    {
        public Customer customer { get; set; }


        //articles details             
        private List<Article> shoppingCartDetails;

        //key = idArticle, value = number of articles with same id        
        private Dictionary<int, int> shoppingCart;


        public Enquiry()
        {
            shoppingCartDetails = new List<Article>();
            shoppingCart = new Dictionary<int, int>();
            customer = new Customer();        }

        
        public void AddArticle(Article article)
        {
            if (shoppingCart.ContainsKey(article.ArticleID))
                shoppingCart[article.ArticleID]++;
            else
            {
                shoppingCart.Add(article.ArticleID, 1);
                shoppingCartDetails.Add(article);
            }
    
        }
        public void RemoveArticle(int IdArticle)
        {
            if (shoppingCart[IdArticle].Equals(1))
            {
                shoppingCart.Remove(IdArticle);
                shoppingCartDetails.RemoveAll(c => c.ArticleID.Equals(IdArticle));
            }
            else
                shoppingCart[IdArticle]--;
        }
        [NotMapped]
        public List<KeyValuePair<Article, int>> ShoppingCart
        {
            get
            {
                return shoppingCart.Select(c => new KeyValuePair<Article, int>(shoppingCartDetails.Single(d => d.ArticleID.Equals(c.Key)), c.Value)).ToList();
            }
        }
        public void EmptyShoppingCart()
        {
            shoppingCartDetails = new List<Article>();
            shoppingCart = new Dictionary<int, int>();
        }
 
    }

    [Table("Title")]
    public class Title
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TitleID { get; set; }
        [Required]
        [StringLength(100)]
        public string TitleDescription { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }

}
