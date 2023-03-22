using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
	[Table("Supplies")]
	public partial class Supply
	{
		[Key]
		[Column("SupplyId")]
		public int SupplyId { get; set; }
		[Column("JobId")]
		public int JobId { get; set; }
		[Required]
		[StringLength(100)]
		public string Material { get; set; }
		[Column("Quantity")]
		public int Quantity { get; set; }
		[Column(TypeName = "money")]
		public decimal MaterialCost { get; set; }
	}
}
