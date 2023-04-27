using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
	[Table("WorkingVersions")]
	public partial class BuildVersion
	{
		[Key]
		[Column("VersionID")]
		public int Id { get; set; }
		public int Major { get; set; }
		public int Minor { get; set; }
		public int Build { get; set; }
		public int Revision { get; set; }
		[Column("AsOfDate", TypeName = "datetime")]
		public DateTime ReleaseDate { get; set; }
		[StringLength(50, ErrorMessage = "must only be 50 chars")]
		public string Comments { get; set; }

		public override string ToString() 
		{
			return $"Id: {Id}, Major: {Major}, Minor: {Minor}, Build: {Build}, Release Date: {ReleaseDate}";
		}
	}
}
