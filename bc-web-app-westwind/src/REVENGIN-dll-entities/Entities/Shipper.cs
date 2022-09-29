using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public partial class Shipper
    {
        public Shipper()
        {
            Shipments = new HashSet<Shipment>();
        }

        [Key]
        [Column("ShipperID")]
        public int ShipperId { get; set; }
        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(24)]
        public string Phone { get; set; }

        [InverseProperty(nameof(Shipment.ShipViaNavigation))]
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
