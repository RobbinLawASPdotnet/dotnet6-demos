using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entities;

namespace DAL
{
	public partial class Context : DbContext
	{
		public override int SaveChanges()
		{
			var entities = from e in ChangeTracker.Entries()
						   where e.State == EntityState.Added
							   || e.State == EntityState.Modified
						   select e.Entity;
			var errors = new List<ValidationResult>();
			foreach (var entity in entities)
			{
				var validationContext = new ValidationContext(entity);
				Validator.TryValidateObject(entity, validationContext, errors, validateAllProperties: true);
			}
			if(errors.Any())
			{
				foreach (ValidationResult result in errors) {
					Console.WriteLine("VALIDATION FAILED: " + result.ToString());
					throw new Exception(result.ToString());
				}
			}
			return base.SaveChanges();
			
		}
	}
}