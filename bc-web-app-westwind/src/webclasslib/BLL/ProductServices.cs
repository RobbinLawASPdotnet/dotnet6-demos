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
	public class ProductServices
	{
		#region Constructor Dependency Injection

		private readonly Context Context;
		public ProductServices(Context context)
		{
			if (context == null)
				throw new ArgumentNullException();
			Context = context;
		}
		#endregion

		#region Queries

		public List<ProductList> FindProductsByPartialName(string partialName)
		{
			Console.WriteLine($"ProductServices: FindProductsByPartialName(); partialName= {partialName}");
			var info =
				Context.Products
				.Where(x => x.ProductName.Contains(partialName))
				.Select(x => new ProductList
				{
					ProductId = x.ProductId,
					ProductName = x.ProductName,
					Supplier = x.Supplier.CompanyName,
					Category = x.Category.CategoryName,
					QuantityPerUnit = x.QuantityPerUnit,
					MinimumOrderQuantity = x.MinimumOrderQuantity,
					UnitPrice = x.UnitPrice,
					UnitsOnOrder = x.UnitsOnOrder,
					Discontinued = x.Discontinued
				})
				.OrderBy(x => x.ProductName);
			return info.ToList();
		}   

		public List<ProductList> FindProductsByCategory(int? id)
		{
			Console.WriteLine($"ProductServices: FindProductsByCategory(); id= {id}");
			var info = 
				Context.Products
				.Where(x=>x.CategoryId == id)
				.Select(x => new ProductList
				{
					ProductId = x.ProductId,
					ProductName = x.ProductName,
					Supplier = x.Supplier.CompanyName,
					Category = x.Category.CategoryName,
					QuantityPerUnit = x.QuantityPerUnit,
					MinimumOrderQuantity = x.MinimumOrderQuantity,
					UnitPrice = x.UnitPrice,
					UnitsOnOrder = x.UnitsOnOrder,
					Discontinued = x.Discontinued
				})
				.OrderBy(x => x.ProductName);
			return info.ToList();
		}

		public ProductItem Retrieve(int id)
		{
			var info = 
				Context.Products
				.Where(x => x.ProductId == id)
				.Select(x => new ProductItem
				{
					ProductId = x.ProductId,
					ProductName = x.ProductName,
					SupplierId = x.SupplierId,
					CategoryId = x.CategoryId,
					QuantityPerUnit = x.QuantityPerUnit,
					MinimumOrderQuantity = x.MinimumOrderQuantity,
					UnitPrice = x.UnitPrice,
					UnitsOnOrder = x.UnitsOnOrder,
					Discontinued = x.Discontinued
				}).FirstOrDefault();
			return info;
		}
		#endregion

		#region Commands: Add, Edit, Delete

		public int Add(ProductItem item)
		{
			Console.WriteLine($"ProductServices: Add; productId= {item.ProductId}");

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

		public void Edit(ProductItem item)
		{
				Console.WriteLine($"ProductServices: Edit; productId= {item.ProductId}");

				//BLL Validation
				Product existing = Context.Products.Find(item.ProductId);
					if (existing == null)
						throw new Exception("Product does not exist");

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

			//BLL Validation
			//cannot delete product if it is in the ManifestItem table
			List<ManifestItem> ManifestItemRecords = 
				Context.ManifestItems
				.Where(x => 
					x.ProductId == item.ProductId)
				.ToList();
			if(ManifestItemRecords.Count != 0)
					throw new Exception("Cannot delete this Product as it is in the ManifestItems table");

			EntityEntry<Product> removing = Context.Entry(existing);
			removing.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
			Context.SaveChanges();
		}
		#endregion
	}
}
