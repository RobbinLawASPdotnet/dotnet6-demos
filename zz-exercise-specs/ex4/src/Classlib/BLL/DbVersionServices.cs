using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Additional Namespaces
using DAL;
using ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BLL 
{
	public class DbVersionServices 
	{
		#region Constructor Dependency Injection
		private readonly Context Context;
		public  DbVersionServices(Context context) 
		{
				if (context == null)
						throw new ArgumentNullException();
				Context = context;
		}
		#endregion

		#region Queries
		public DbVersionView GetDbVersion() 
		{
			Console.WriteLine($"DbServices: GetDbVersion;");
			List<DbVersionView> info = 
			Context.DbVersions
			.Select(x => new DbVersionView
			{
				Id = x.Id,
				Major = x.Major,
				Minor = x.Minor,
				Build = x.Build,
				ReleaseDate = x.ReleaseDate
			})
			.ToList();
			return info.First();
		}
		#endregion 
	}
}