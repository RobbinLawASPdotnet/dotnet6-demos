using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public partial class Payment
    {
        [Key]
        [Column("PaymentID")]
        public int PaymentId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime PaymentDate { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal Amount { get; set; }
        [Column("PaymentTypeID")]
        public byte PaymentTypeId { get; set; }
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("TransactionID")]
        public Guid TransactionId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ClearedDate { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("Payments")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(PaymentTypeId))]
        [InverseProperty("Payments")]
        public virtual PaymentType PaymentType { get; set; }
    }
}
