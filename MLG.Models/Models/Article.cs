using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MLG.Models.Models
{
    public partial class Article
    {
        public Article()
        {
            ArticleStores = new HashSet<ArticleStore>();
            CustomerArticles = new HashSet<CustomerArticle>();
        }

        [Key]
        public int PKArticle { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        [Required]
        public string Image { get; set; }
        public int Stock { get; set; }
        [Required]
        public bool? IsAvailable { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; }

        [InverseProperty(nameof(ArticleStore.FKArticleNavigation))]
        public virtual ICollection<ArticleStore> ArticleStores { get; set; }
        [InverseProperty(nameof(CustomerArticle.FKArticleNavigation))]
        public virtual ICollection<CustomerArticle> CustomerArticles { get; set; }
    }
}
