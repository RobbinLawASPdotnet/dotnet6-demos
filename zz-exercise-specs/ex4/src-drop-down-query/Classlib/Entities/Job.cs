using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
	[Table("Jobs")]
	public partial class Job
	{
		[Key]
		[Column("JobId")]
		public int JobId { get; set; }
		[Column("ClientId")]
		public int ClientId { get; set; }
		[Required]
		[StringLength(500)]
		public string Description { get; set; }
		[Column(TypeName = "datetime")]
		public DateTime StartDate { get; set; }
		[Column(TypeName = "datetime")]
		public DateTime CompletionDate { get; set; }
		[Required]
		[StringLength(12)]
		public string PlanId { get; set; }
	}
}
