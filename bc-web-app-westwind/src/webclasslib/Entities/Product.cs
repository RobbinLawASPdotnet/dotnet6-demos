using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
	public partial class Product
	{
		[Key]
		[Column("ProductID")]
		public int ProductId { get; set; }
		[Required(ErrorMessage = "You must supply a product name")]
		[StringLength(40, ErrorMessage = "Product Name must be only 40 chars")]
		public string ProductName { get; set; }
		[Column("SupplierID")]
		public int SupplierId { get; set; }
		[Column("CategoryID")]
		public int CategoryId { get; set; }
		[Required(ErrorMessage = "You must supply a quantity per unit")]
		[StringLength(20, ErrorMessage = "Quantity Per Unit must be only 20 chars")]
		public string QuantityPerUnit { get; set; }
		public short? MinimumOrderQuantity { get; set; }
		[Column(TypeName = "money")]
		public decimal UnitPrice { get; set; }
		public int UnitsOnOrder { get; set; }
		public bool Discontinued { get; set; }

		[ForeignKey(nameof(CategoryId))]
		[InverseProperty("Products")]
		public virtual Category Category { get; set; }
		[ForeignKey(nameof(SupplierId))]
		[InverseProperty("Products")]
		public virtual Supplier Supplier { get; set; }
		[InverseProperty(nameof(OrderDetail.Product))]
		public virtual ICollection<OrderDetail> OrderDetails { get; set; }
	}
}
