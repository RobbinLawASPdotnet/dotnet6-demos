using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//Additional namespaces
using BLL;
using ViewModels;

namespace MyApp.Namespace
{
	public class QueryCrudModel : PageModel
	{
		private readonly ProgramServices ProgramServices;
		private readonly SchoolServices SchoolServices;
		
		public QueryCrudModel(ProgramServices programservices,
													SchoolServices schoolservices)
		{
			ProgramServices = programservices;
			SchoolServices = schoolservices;
		}

		public string SuccessMessage { get; set; }
		public string ErrorMessage { get; set; }
		public List<Exception> Errors {get; set;} = new();
		[BindProperty]
		public string ButtonPressed {get; set;}
		
		//TODO: Put your properties here
		
		public IActionResult OnGet()
		{
			try
			{
				Console.WriteLine("QueryModel: OnGet");
				//TODO: Put your code here

			}
			catch (Exception ex)
			{
				ErrorMessage = GetInnerException(ex);
			}
			return Page();
		}

		public IActionResult OnPost()
		{
			try
			{
				Console.WriteLine("QueryModel: OnPost");
				//TODO: Put your code here
				
			}
			catch (AggregateException ex)
			{
				ErrorMessage = ex.Message;
			}
			catch (Exception ex)
			{
				ErrorMessage = GetInnerException(ex);
			}
			//TODO: Put your code here

			return Page();
			
		}

		//TODO: Put your methods here.

		public string GetInnerException(Exception e)
		{
			Exception rootCause = e;
			while (rootCause.InnerException != null)
					rootCause = rootCause.InnerException;
			return rootCause.Message;
		}
	}
}

