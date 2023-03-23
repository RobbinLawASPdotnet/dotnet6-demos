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
	public class JobServices
	{
		#region Constructor Dependency Injection
		private readonly Context Context;
		public JobServices(Context context)
		{
			if (context == null)
				throw new ArgumentNullException();
			Context = context;
		}
		#endregion

		#region Queries
		public List<SelectionList> ListJobs()
		{
			List<SelectionList> info = 
				Context.Jobs
				.Select(x => new SelectionList
				{
					ValueField = x.JobId,
					DisplayField = x.Description
				})
				.OrderBy(x => x.DisplayField)
				.ToList();
			return info;
		}
		#endregion

	}
}
