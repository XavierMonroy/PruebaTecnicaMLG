using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MLG.API.ViewModels
{
    public class CustomerDropDownModel
    {
        [Required]
        public int PKCustomer { get; set; }
        [Required]
        public string Name { get; set; }
    }
}