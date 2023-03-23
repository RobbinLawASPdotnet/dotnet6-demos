using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Our added dependencies
using System.Text.Json;
using Models;

namespace MyApp.Namespace
{
	public class RoyalFamilyInfoModel : PageModel
	{
		private IWebHostEnvironment WebHostEnvironment;
		public RoyalFamilyInfoModel(IWebHostEnvironment webHostEnvironment)
		{
			WebHostEnvironment = webHostEnvironment;
		}

		public string SuccessMessage {get; set;}
		public string ErrorMessage {get; set;}
		public RoyalFamily CurrentRoyalFamily { get; private set; }
		
		public IActionResult OnGet()
		{
			try
			{
				
			}
			catch (Exception ex)
			{
				ErrorMessage = GetInnerException(ex);
			}
			return Page();            
		}

		public string GetInnerException(Exception e)
		{
			Exception rootCause = e;
			while (rootCause.InnerException != null)
				rootCause = rootCause.InnerException;
			return rootCause.Message;
		}
	}
}
