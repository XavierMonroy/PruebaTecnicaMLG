using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MLG.Models.Models
{
    [Index(nameof(User), Name = "UNIQ_Customers_User", IsUnique = true)]
    public partial class Customer
    {
        public Customer()
        {
            CustomerArticles = new HashSet<CustomerArticle>();
        }

        [Key]
        public int PKCustomer { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        public string User { get; set; }
        public byte[] Password { get; set; }
        public int FKRole { get; set; }
        [Required]
        public bool? IsAvailable { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; }

        [ForeignKey(nameof(FKRole))]
        [InverseProperty(nameof(Role.Customers))]
        public virtual Role FKRoleNavigation { get; set; }
        [InverseProperty(nameof(CustomerArticle.FKCustomerNavigation))]
        public virtual ICollection<CustomerArticle> CustomerArticles { get; set; }
    }
}
