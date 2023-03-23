using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ViewModels
{

	public class SupplyItem
	{
		public int SupplyId { get; set; }
		public int JobId { get; set; }
		public string Material { get; set; }
		public int Quantity { get; set; }
		public decimal MaterialCost { get; set; }
	}
}
