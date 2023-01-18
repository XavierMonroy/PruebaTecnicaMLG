using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MLG.Models.Models
{
    [Table("CustomerArticle")]
    public partial class CustomerArticle
    {
        [Key]
        public int PKCustomerArticle { get; set; }
        public int FKCustomer { get; set; }
        public int FKArticle { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Required]
        public bool? IsAvailable { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; }

        [ForeignKey(nameof(FKArticle))]
        [InverseProperty(nameof(Article.CustomerArticles))]
        public virtual Article FKArticleNavigation { get; set; }
        [ForeignKey(nameof(FKCustomer))]
        [InverseProperty(nameof(Customer.CustomerArticles))]
        public virtual Customer FKCustomerNavigation { get; set; }
    }
}
