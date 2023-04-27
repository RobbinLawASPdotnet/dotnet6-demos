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
			: base(options)
		{
		}

		public DbSet<BuildVersion> BuildVersions { get; set; }
		public DbSet<School> Schools { get; set; }
		public DbSet<Program> Programs { get; set; }

	}
}
