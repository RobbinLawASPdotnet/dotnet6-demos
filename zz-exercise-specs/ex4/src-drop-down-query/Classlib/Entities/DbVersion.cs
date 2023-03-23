using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
  // The Table("TableName") must be the name of the database table.
  // It may or may not be the same as the class name DbVersion.
	[Table("DbVersion")]
	public partial class DbVersion
	{
		[Key]
		public int Id { get; set; }
		public int Major { get; set; }
		public int Minor { get; set; }
		public int Build { get; set; }
		[Column(TypeName = "datetime")]
		public DateTime ReleaseDate { get; set; }
	}
}