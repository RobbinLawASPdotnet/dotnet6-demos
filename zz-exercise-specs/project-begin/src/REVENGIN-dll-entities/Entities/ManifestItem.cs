using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public partial class ManifestItem
    {
        [Key]
        [Column("ManifestItemID")]
        public int ManifestItemId { get; set; }
        [Column("ShipmentID")]
        public int ShipmentId { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        public short ShipQuantity { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ManifestItems")]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(ShipmentId))]
        [InverseProperty("ManifestItems")]
        public virtual Shipment Shipment { get; set; }
    }
}
