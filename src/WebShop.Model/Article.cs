using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebShop.Model
{
    [Table("Article")]
    public class Article
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ArticleID { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Summary { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal VATRate { get; set; }
        [NotMapped]
        public decimal TotalPrice
        {
            get { return Price + (Price * VATRate / 100); }
        }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [NotMapped]
        public string FormattedPrice
        {
            get { return String.Format("{0:0.00}", Price); }
        }
        [NotMapped]
        public string FormattedVAT
        {
            get { return String.Format("{0:0.00}", VATRate); }
        }
        [NotMapped]
        public string FormattedTotalPrice
        {
            get { return String.Format("{0:0.00}", Price + (Price*VATRate/100)); }
        }

    }
}
