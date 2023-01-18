using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MLG.Models.Models
{
    [Table("ArticleStore")]
    public partial class ArticleStore
    {
        [Key]
        public int PKArticleStore { get; set; }
        public int FKArticle { get; set; }
        public int FKStore { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Required]
        public bool? IsAvailable { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; }

        [ForeignKey(nameof(FKArticle))]
        [InverseProperty(nameof(Article.ArticleStores))]
        public virtual Article FKArticleNavigation { get; set; }
        [ForeignKey(nameof(FKStore))]
        [InverseProperty(nameof(Store.ArticleStores))]
        public virtual Store FKStoreNavigation { get; set; }
    }
}
