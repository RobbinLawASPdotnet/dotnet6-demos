using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Our added dependencies
using System.Text;
using Models;

namespace MyApp.Namespace
{
	public class PersonInfoModel : PageModel
	{
		public string SuccessMessage {get; set;}
		public string ErrorMessage {get; set;}
		public List<Exception> errors {get; set;} = new();
		[BindProperty]
		public string ButtonPressed {get; set;}
		[BindProperty]
		public string PersonName { get; set; }
		[BindProperty]
		public DateTime PersonDateOfBirth { get; set; } 
		[BindProperty]
		public DateTime PersonAgeOnDate { get; set; }

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

		public IActionResult OnPost()
		{
			try
			{
				
			}
			catch (AggregateException e)
			{
				ErrorMessage = e.Message;
			}
			catch (Exception e)
			{
				ErrorMessage = GetInnerException(e);
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
