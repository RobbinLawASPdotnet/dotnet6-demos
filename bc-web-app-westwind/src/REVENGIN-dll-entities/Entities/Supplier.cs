using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    [Index(nameof(CompanyName), Name = "CompanyName")]
    [Index(nameof(AddressId), Name = "UX_Suppliers_AddressID", IsUnique = true)]
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("SupplierID")]
        public int SupplierId { get; set; }
        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(30)]
        public string ContactName { get; set; }
        [StringLength(30)]
        public string ContactTitle { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("AddressID")]
        public int AddressId { get; set; }
        [Required]
        [StringLength(24)]
        public string Phone { get; set; }
        [StringLength(24)]
        public string Fax { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Supplier")]
        public virtual Address Address { get; set; }
        [InverseProperty(nameof(Product.Supplier))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
