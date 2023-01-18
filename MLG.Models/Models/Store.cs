using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MLG.Models.Models
{
    public partial class Store
    {
        public Store()
        {
            ArticleStores = new HashSet<ArticleStore>();
        }

        [Key]
        public int PKStore { get; set; }
        [Required]
        [StringLength(50)]
        public string Subsidiary { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        public bool? IsAvailable { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; }

        [InverseProperty(nameof(ArticleStore.FKStoreNavigation))]
        public virtual ICollection<ArticleStore> ArticleStores { get; set; }
    }
}
