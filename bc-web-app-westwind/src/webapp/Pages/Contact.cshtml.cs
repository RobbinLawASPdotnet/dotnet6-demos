//https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input
//https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references

//#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
	public class ContactModel : PageModel
	{
		public string SuccessMessage {get; set;}
		public string ErrorMessage {get; set;}
		public List<Exception> errors {get; set;} = new();
		
		public string Text1{get;set;}
		public int Number1{get;set;}

		[BindProperty] 
		public string Text2{get;set;}
		[BindProperty] 
		public int Number2{get;set;}

		[BindProperty] 
		public string Text3{get;set;}
		[BindProperty] 
		public int Number3{get;set;}
		
		[BindProperty]
		public string Email{get;set;}
		[BindProperty]
		public DateTime MyDate{get;set;}
		[BindProperty]
		public string MessageBody{get;set;}
		[BindProperty]
		public string CheckBox{get;set;}
		[BindProperty]
		public string Radio{get;set;}
		public string[] RadioOptions = {"email","phone","snail mail"};
	
		[BindProperty]
		public string ButtonPressed {get; set;}

		public List<string> SelectListOfSubjects{get;set;}
		[BindProperty]
		public int SelectedSubjectId {get;set;}

		public IActionResult OnGet()
		{
			try
			{
				Console.WriteLine($"ContactModel: OnGet");
				PopulateSelectLists();
				SelectedSubjectId = 2;
				Text2 = "Robbin Law";
				Number2 = 12;
				Radio = "email";
			}
			catch (Exception e)
			{ 
				ErrorMessage = GetInnerException(e);
			}
			return Page();
		}

		private void PopulateSelectLists()
		{
				SelectListOfSubjects = new List<string>(){"select...", "Contributing", "Request Membership", "Bug Report"};  
		}

		public IActionResult OnPost(string text1, string number1)
		{
			try
			{
				Console.WriteLine($"ContactModel: OnPost");
				Text1 = text1;
				if(!string.IsNullOrEmpty(number1))
					Number1 = int.Parse(number1);

				PopulateSelectLists();
				
				if(ButtonPressed == "Submit")
				{
					// Client Side Validation
					if (string.IsNullOrEmpty(Text2))
						errors.Add(new Exception("Text2"));
					if (string.IsNullOrEmpty(Radio))
						errors.Add(new Exception("Radio"));
					if (SelectedSubjectId == 0)
						errors.Add(new Exception("DropDown"));
					
					if (errors.Count() > 0)
						throw new AggregateException("Missing Data: ", errors);

					if (Text2.Trim().Length < 3)
						errors.Add(new Exception("Text2 < 3"));
					if (Number2 < 11)
						errors.Add(new Exception("Number2 < 11"));

					if (errors.Count() > 0)
						throw new AggregateException("Bad Data: ", errors);

					SuccessMessage = $"T1={Text1}, T2={Text2}, T3={Text3}, N1={Number1}, N2={Number2}, N3={Number3}, Email={Email}, Date={MyDate}, Subject={SelectListOfSubjects[SelectedSubjectId]}, Text={MessageBody}, CheckBox={CheckBox}, Radio={Radio}";

				} else if(ButtonPressed == "Clear")
				{
					Text1 = "";
					Number1 = 0;
					Text2 = "";
					Number2 = 0;
					Text3 = "";
					Number3 = 0;
					Email = "";
					MyDate = DateTime.MinValue;
					SelectedSubjectId = 0;
					MessageBody = "";
					CheckBox = null;
					Radio = "";
					SuccessMessage = "Clear Successful";
					//throw new Exception("Clear button just threw an exception but lucky we caught it.");
				}
			}
			catch (AggregateException e)
			{
				ErrorMessage = "Thrown in catch (AggregateException) " + e.Message;
			}
			catch (Exception e)
			{
				ErrorMessage = "Thrown in catch (Exception) " + GetInnerException(e);
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