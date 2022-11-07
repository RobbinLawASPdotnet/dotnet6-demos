using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
	[Table("OrderDetails")]
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
		[Column(TypeName = "smallint")]
		public short Quantity { get; set; }
		[Column(TypeName = "real")]
		public float Discount { get; set; }

		[ForeignKey(nameof(ProductId))]
		[InverseProperty("OrderDetails")]
		public virtual Product Product { get; set; }
	}
}
