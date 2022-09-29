using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public partial class Shipment
    {
        public Shipment()
        {
            ManifestItems = new HashSet<ManifestItem>();
        }

        [Key]
        [Column("ShipmentID")]
        public int ShipmentId { get; set; }
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ShippedDate { get; set; }
        public int ShipVia { get; set; }
        [Column(TypeName = "money")]
        public decimal FreightCharge { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string TrackingCode { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("Shipments")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(ShipVia))]
        [InverseProperty(nameof(Shipper.Shipments))]
        public virtual Shipper ShipViaNavigation { get; set; }
        [InverseProperty(nameof(ManifestItem.Shipment))]
        public virtual ICollection<ManifestItem> ManifestItems { get; set; }
    }
}
