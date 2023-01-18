using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MLG.API.ViewModels
{
    public class ArticlesDropDownModel
    {
        [Required]
        public int PKArticle { get; set; }
        [Required]
        public string Description { get; set; }
    }
}