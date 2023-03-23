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
		private readonly JobServices JobServices;
		private readonly SupplyServices SupplyServices;

		public QueryCrudModel(JobServices jobservices,
													SupplyServices supplyservices)
		{
			JobServices = jobservices;
			SupplyServices = supplyservices;
		}

		public string SuccessMessage { get; set; }
		public string ErrorMessage { get; set; }
		public List<Exception> Errors {get; set;} = new();
		[BindProperty]
		public string ButtonPressed {get; set;}
		[BindProperty]
		public int SelectedJobId {get;set;}
		[BindProperty]
		public List<SupplyItem> SearchedSupplies { get; set; }
		[BindProperty]
		public List<SelectionList> SelectListOfJobs {get;set;}
		
		public IActionResult OnGet()
		{
			try
			{
				Console.WriteLine("QueryModel: OnGet");
				PopulateSelectLists();
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
				//TODO1: Put your code in this try

			}
			catch (AggregateException ex)
			{
				ErrorMessage = ex.Message;
			}
			catch (Exception ex)
			{
				ErrorMessage = GetInnerException(ex);
			}
			PopulateSelectLists();
			GetSupplies();
			return Page();
			
		}

		private void PopulateSelectLists()
		{
			try
			{
				Console.WriteLine("Querymodel: PopulateSelectLists");
				//TODO2: Put your code in this try
				
			}
			catch (Exception ex)
			{ 
				ErrorMessage = GetInnerException(ex);
			}
		}

		private void GetSupplies()
		{
			try
			{
				Console.WriteLine($"QueryCrudModel: GetSupplies");
				//TODO3: Put your code in this try

			}
			catch (Exception ex)
			{ 
				ErrorMessage = GetInnerException(ex);
			}
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

