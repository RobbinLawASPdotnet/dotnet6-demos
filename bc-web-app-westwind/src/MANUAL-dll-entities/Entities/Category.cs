using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Entities
{
	public class Category
	{
		[Key]
		[Column("CategoryID")]
		public int CategoryId { get; set; }
		[Required]
		[StringLength(15)]
		public string CategoryName { get; set; }
		[Column(TypeName = "ntext")]
		public string Description { get; set; }
		public byte[] Picture { get; set; }
		[StringLength(40)]
		public string PictureMimeType { get; set; }
	}
}
