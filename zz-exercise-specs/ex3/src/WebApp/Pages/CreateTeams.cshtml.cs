using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
	public class CreateTeamsModel : PageModel
	{
		public string SuccessMessage {get; set;}
		public string ErrorMessage {get; set;}
		public List<Exception> errors {get; set;} = new();
		[BindProperty]
		public string ButtonPressed {get; set;}

		[BindProperty]
		public string MemberList { get; set; }
		[BindProperty]
		public int MembersPerGroup { get; set; } = 3;

		public List<string> OriginalMembers { get; private set; }
		public List<string> ShuffledMembers { get; private set; }

		public void OnGet()
		{
		}

		public IActionResult OnPost()
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
