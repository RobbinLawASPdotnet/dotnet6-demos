using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    [Index(nameof(CustomerId), Name = "CustomerID")]
    [Index(nameof(CustomerId), Name = "CustomersOrders")]
    [Index(nameof(SalesRepId), Name = "EmployeeID")]
    [Index(nameof(SalesRepId), Name = "EmployeesOrders")]
    [Index(nameof(OrderDate), Name = "OrderDate")]
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Payments = new HashSet<Payment>();
            Shipments = new HashSet<Shipment>();
        }

        [Key]
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("SalesRepID")]
        public int? SalesRepId { get; set; }
        [Required]
        [Column("CustomerID")]
        [StringLength(5)]
        public string CustomerId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RequiredDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PaymentDueDate { get; set; }
        [Column(TypeName = "money")]
        public decimal? Freight { get; set; }
        public bool Shipped { get; set; }
        [StringLength(40)]
        public string ShipName { get; set; }
        [Column("ShipAddressID")]
        public int? ShipAddressId { get; set; }
        [StringLength(250)]
        public string Comments { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Orders")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(SalesRepId))]
        [InverseProperty(nameof(Employee.Orders))]
        public virtual Employee SalesRep { get; set; }
        [ForeignKey(nameof(ShipAddressId))]
        [InverseProperty(nameof(Address.Orders))]
        public virtual Address ShipAddress { get; set; }
        [InverseProperty(nameof(OrderDetail.Order))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [InverseProperty(nameof(Payment.Order))]
        public virtual ICollection<Payment> Payments { get; set; }
        [InverseProperty(nameof(Shipment.Order))]
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
