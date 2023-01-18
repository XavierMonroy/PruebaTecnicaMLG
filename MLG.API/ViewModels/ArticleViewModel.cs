using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MLG.API.ViewModels
{
    public class ArticleViewModel
    {
        [Required]
        public int PKArticle { get; set; }
        [Required]
        public string ArticleName { get; set; }
        [Required]
        public string Code { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }
        public bool IsAvailable { get; set; }
    }
}