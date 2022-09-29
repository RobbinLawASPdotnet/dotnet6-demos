
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
	public class CategoryServices
	{
		#region Constructor Dependency Injection
		private readonly Context Context;
		public CategoryServices(Context context)
		{
			if (context == null)
				throw new ArgumentNullException();
			Context = context;
		}
		#endregion

		#region Queries
		public List<SelectionList> ListCategories()
		{
			List<SelectionList> info = 
				Context.Categories
				.Select(x => new SelectionList
				{
					ValueField = x.CategoryId,
					DisplayField = x.CategoryName
				})
				.OrderBy(x => x.DisplayField)
				.ToList();
			return info;
		}
		#endregion

	}
}
