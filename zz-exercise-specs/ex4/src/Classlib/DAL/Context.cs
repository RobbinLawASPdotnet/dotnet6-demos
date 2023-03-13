using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Additional Namespaces
using Entities;

namespace DAL 
{
	public class Context : DbContext 
	{
		public Context(DbContextOptions<Context> options)
			: base(options) {}

		public DbSet<DbVersion> DbVersions { get; set; }
	}
}