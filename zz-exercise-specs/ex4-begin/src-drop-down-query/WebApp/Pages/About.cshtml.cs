using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Additional Namespaces
using ViewModels;
using BLL;

namespace MyApp.Namespace
{
	public class AboutModel : PageModel
	{
		private readonly DbVersionServices Services;
		public AboutModel(DbVersionServices services) {
		   Services = services;
		}

		public DbVersionView DatabaseVersion { get; set; }

		public string SuccessMessage {get; set;}
		public string ErrorMessage {get; set;}

		public void OnGet()
		{
			try
			{
				Console.WriteLine($"AboutModel: OnGet");
				DatabaseVersion = Services.GetDbVersion();
				Console.WriteLine($"XXXXXXXXXXXXXXXXXXX: {DatabaseVersion.ToString()}");
				SuccessMessage = $"Database Retrieve Successful";
			}
			catch (Exception ex)
			{
				ErrorMessage = GetInnerException(ex);
			}
			
		}

		public string GetInnerException(Exception ex)
		{
			Exception rootCause = ex;
			while (rootCause.InnerException != null)
				rootCause = rootCause.InnerException;
			return rootCause.Message;
		}
	}
}
