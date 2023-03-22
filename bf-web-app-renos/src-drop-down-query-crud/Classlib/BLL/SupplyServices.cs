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
					
				existing.ProductId = item.ProductId;
				existing.ProductName = item.ProductName;
				existing.SupplierId = item.SupplierId;
				existing.CategoryId = item.CategoryId;
				existing.QuantityPerUnit = item.QuantityPerUnit;
				existing.MinimumOrderQuantity = item.MinimumOrderQuantity;
				existing.UnitPrice = item.UnitPrice;
				existing.UnitsOnOrder = item.UnitsOnOrder;
				existing.Discontinued = item.Discontinued;

				EntityEntry<Product> updating = Context.Entry(existing);
				updating.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				Context.SaveChanges();
		}

		public int Add(SupplyItem item)
		{
			Console.WriteLine($"SupplyServices: Add; supplyId= {item.SupplyId}");

			//BLL Validation
			//for no product duplicates
			var exists = 
				Context.Products.FirstOrDefault(x => 
				x.ProductName == item.ProductName && 
				x.SupplierId == item.SupplierId &&
				x.CategoryId == item.CategoryId &&  
				x.QuantityPerUnit == item.QuantityPerUnit);
			if (exists != null)
				throw new Exception("A product with the same name, supplier, category, and quantity per unit already exists");

			var newProduct = new Product();
			newProduct.ProductId = item.ProductId;
			newProduct.ProductName = item.ProductName;
			newProduct.SupplierId = item.SupplierId;
			newProduct.CategoryId = item.CategoryId;
			newProduct.QuantityPerUnit = item.QuantityPerUnit;
			newProduct.MinimumOrderQuantity = item.MinimumOrderQuantity;
			newProduct.UnitPrice = item.UnitPrice;
			newProduct.UnitsOnOrder = item.UnitsOnOrder;
			newProduct.Discontinued = item.Discontinued;

			Context.Products.Add(newProduct);
			Context.SaveChanges();
			return newProduct.ProductId;
		}

		public void Delete(ProductItem item)
		{
			Console.WriteLine($"ProductServices: Delete; productId= {item.ProductId}");

			//BLL Validation
			Product existing = Context.Products.Find(item.ProductId);
				if (existing == null)
			 		throw new Exception("Product does not exist");

			//BLL Validation
			//cannot delete product if it is in the OderDetail table
			List<OrderDetail> OrderDetailRecords = 
				Context.OrderDetails
				.Where(x => 
					x.ProductId == item.ProductId)
				.ToList();
			if(OrderDetailRecords.Count != 0)
					throw new Exception("Cannot delete this Product as it is in the OrderDetails table");

			EntityEntry<Product> removing = Context.Entry(existing);
			removing.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
			Context.SaveChanges();
		}
		#endregion
		
	}
}
