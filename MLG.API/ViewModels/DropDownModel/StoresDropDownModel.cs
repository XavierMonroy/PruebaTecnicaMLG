using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MLG.API.ViewModels
{
    public class StoresDropDownModel
    {
        [Required]
        public int PKStore { get; set; }
        [Required]
        public string Subsidiary { get; set; }
    }
}