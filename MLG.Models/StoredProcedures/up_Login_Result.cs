using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLG.Models.StoredProcedures
{
    public class up_Login_Result
    {
        [Required]
        [Key]
        public int PKCustomer { get; set; }
        [Required]
        public string User { get; set; }
        [Required]
        public int FKRole { get; set; }
    }

}
