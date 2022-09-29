using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Payments = new HashSet<Payment>();
        }

        [Key]
        [Column("PaymentTypeID")]
        public byte PaymentTypeId { get; set; }
        [Required]
        [StringLength(40)]
        [Unicode(false)]
        public string PaymentTypeDescription { get; set; }

        [InverseProperty(nameof(Payment.PaymentType))]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
