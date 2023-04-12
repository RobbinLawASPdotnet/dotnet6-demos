using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Additional Namespaces
using DAL;
using Entities;
using ViewModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BLL
{
	public class SupplyServices
	{
		#region Constructor Dependency Injection
		private readonly Context Context;
		public SupplyServices(Context context)
		{
			if (context == null)
				throw new ArgumentNullException();
			Context = context;
		}
		#endregion

		#region Queries

		public List<SupplyItem> FindSuppliesByJob(int id)
		{
			Console.WriteLine($"SupplyServices: FindSuppliesByJob(); id= {id}");
			var info = 
				Context.Supplies
				.Where(x => x.JobId == id)
				.Select(x => new SupplyItem
				{
					SupplyId = x.SupplyId,
					JobId = x.JobId,
					Material = x.Material,
					Quantity = x.Quantity,
					MaterialCost = x.MaterialCost
				})
				.OrderBy(x => x.Material);
			return info.ToList();
		}

		#endregion

		#region READ - Retrieve, Edit, Add, Delete
		// CRUD - Create, Read/Write, Update, Delete
		public SupplyItem Retrieve(int id)
		{
			var info = 
				Context.Supplies
				.Where(x => x.SupplyId == id)
				.Select(x => new SupplyItem
				{
					SupplyId = x.SupplyId,
					JobId = x.JobId,
					Material = x.Material,
					Quantity = x.Quantity,
					MaterialCost = x.MaterialCost
				}).FirstOrDefault();
			return info;
		}

		public void Edit(SupplyItem item)
		{
				Console.WriteLine($"SupplyServices: Edit; supplyId= {item.SupplyId}");

				//BLL Validation
				Supply existing = Context.Supplies.Find(item.SupplyId);
					if (existing == null)
						throw new Exception("Supply does not exist");
					
				existing.JobId = item.JobId;
				existing.Material = item.Material;
				existing.Quantity = item.Quantity;
				existing.MaterialCost = item.MaterialCost;

				EntityEntry<Supply> updating = Context.Entry(existing);
				updating.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				Context.SaveChanges();
		}

		public int Add(SupplyItem item)
		{
			Console.WriteLine($"SupplyServices: Add; supplyId= {item.SupplyId}");

			//BLL Validation
			//for no supply duplicates
			var exists = 
				Context.Supplies.FirstOrDefault(x => 
				x.JobId == item.JobId && 
				x.Material == item.Material &&
				x.Quantity == item.Quantity &&  
				x.MaterialCost == item.MaterialCost);
			if (exists != null)
				throw new Exception("A supply with the same job, material, quantity, and material cost already exists");

			var newSupply = new Supply();
			newSupply.SupplyId = item.SupplyId;
			newSupply.JobId = item.JobId;
			newSupply.Material = item.Material;
			newSupply.Quantity = item.Quantity;
			newSupply.MaterialCost = item.MaterialCost;

			Context.Supplies.Add(newSupply);
			Context.SaveChanges();
			return newSupply.SupplyId;
		}

		public void Delete(SupplyItem item)
		{
			Console.WriteLine($"SupplyServices: Delete; supplyId= {item.SupplyId}");

			//BLL Validation
			Supply existing = Context.Supplies.Find(item.SupplyId);
				if (existing == null)
			 		throw new Exception("Supply does not exist");

			EntityEntry<Supply> removing = Context.Entry(existing);
			removing.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
			Context.SaveChanges();
		}

		#endregion	
	}
}
