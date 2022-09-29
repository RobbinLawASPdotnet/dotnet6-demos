using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public partial class Address
    {
        public Address()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("AddressID")]
        public int AddressId { get; set; }
        [Required]
        [Column("Address")]
        [StringLength(60)]
        public string Address1 { get; set; }
        [Required]
        [StringLength(15)]
        public string City { get; set; }
        [StringLength(15)]
        public string Region { get; set; }
        [StringLength(10)]
        public string PostalCode { get; set; }
        [Required]
        [StringLength(15)]
        public string Country { get; set; }

        [InverseProperty("Address")]
        public virtual Customer Customer { get; set; }
        [InverseProperty("Address")]
        public virtual Employee Employee { get; set; }
        [InverseProperty("Address")]
        public virtual Supplier Supplier { get; set; }
        [InverseProperty(nameof(Order.ShipAddress))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
