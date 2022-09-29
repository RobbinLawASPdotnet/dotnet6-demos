
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using DAL;
using ViewModels;
#endregion

namespace BLL
{
	public class SupplierServices
	{
		#region Constructor Dependency Injection
		private readonly Context Context;
		public SupplierServices(Context context)
		{
			if (context == null)
				throw new ArgumentNullException();
			Context = context;
		}
		#endregion

		#region Queries
		public List<SelectionList> ListSuppliers()
		{
			List<SelectionList> info = 
				Context.Suppliers
				.Select(x => new SelectionList
				{
					ValueField = x.SupplierId,
					DisplayField = x.CompanyName
				})
				.OrderBy(x => x.DisplayField)
				.ToList();
			return info;
		}
		#endregion

	}
}
