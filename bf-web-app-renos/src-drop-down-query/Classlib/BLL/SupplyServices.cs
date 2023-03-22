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

		public List<SupplyList> FindSuppliesByJob(int? id)
		{
			Console.WriteLine($"SupplyServices: FindSuppliesByJob(); id= {id}");
			var info = 
				Context.Supplies
				.Where(x=>x.JobId == id)
				.Select(x => new SupplyList
				{
					SupplyId = x.SupplyId,
					JobId = x.JobId,
					Material = x.Material,
					Quantity = x.Quantity,
					MaterialCost = x.MaterialCost,
				})
				.OrderBy(x => x.Material);
			return info.ToList();
		}
		#endregion
	}
}
