﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    [Index(nameof(OrderId), Name = "OrderID")]
    [Index(nameof(OrderId), Name = "OrdersOrder_Details")]
    [Index(nameof(ProductId), Name = "ProductID")]
    [Index(nameof(ProductId), Name = "ProductsOrder_Details")]
    public partial class OrderDetail
    {
        [Key]
        [Column("OrderDetailID")]
        public int OrderDetailId { get; set; }
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderDetails")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("OrderDetails")]
        public virtual Product Product { get; set; }
    }
}
