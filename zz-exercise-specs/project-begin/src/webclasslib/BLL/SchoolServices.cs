using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Additional Namespaces
using DAL;
using ViewModels;

namespace BLL
{
	public class SchoolServices
	{
		#region Constructor Dependency Injection
		private readonly Context Context;
		public SchoolServices(Context context)
		{
			if (context == null)
				throw new ArgumentNullException();
			Context = context;
		}
		#endregion

		#region Queries
		public List<SelectionList> ListSchools()
		{
			List<SelectionList> info = 
				Context.Schools
				.Select(x => new SelectionList
				{
					ValueField = x.SchoolCode,
					DisplayField = x.SchoolName
				})
				.OrderBy(x => x.DisplayField)
				.ToList();
			return info;
		}
		#endregion

	}
}
