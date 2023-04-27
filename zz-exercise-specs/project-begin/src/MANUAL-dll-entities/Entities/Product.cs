using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Entities
{
	public class Product
	{
		[Key]
		[Column("ProductID")]
		public int ProductId { get; set; }
		[Required(ErrorMessage = "You must supply a product name")]
		[StringLength(40, MinimumLength = 5, ErrorMessage = "Product names should be between 5 and 40 character inclusive")]
		public string ProductName { get; set; }
		[Column("SupplierID")]
		public int SupplierId { get; set; }
		[Column("CategoryID")]
		public int CategoryId { get; set; }
		[Required]
		[StringLength(20, ErrorMessage = "Quantity Per Unit must be only 20 characters")]
		public string QuantityPerUnit { get; set; }
		public short? MinimumOrderQuantity { get; set; }
		[Column(TypeName = "money")]
		public decimal UnitPrice { get; set; }
		public int UnitsOnOrder { get; set; }
		public bool Discontinued { get; set; }
	}
}
