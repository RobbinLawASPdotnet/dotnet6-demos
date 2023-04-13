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
		[BindProperty]
		public SupplyItem Supply {get;set;} = new();
		
		public IActionResult OnGet()
		{
			try
			{
				Console.WriteLine("QueryCrudModel: OnGet");
				PopulateSelectLists();
			}
			catch (Exception ex)
			{
				ErrorMessage = GetInnerException(ex);
			}
			return Page();
		}

		private void PopulateSelectLists()
		{
			try
			{
				Console.WriteLine("QueryCrudModel: PopulateSelectLists");
				SelectListOfJobs = JobServices.ListJobs();
				
			}
			catch (Exception ex)
			{ 
				ErrorMessage = GetInnerException(ex);
			}
		}
		
		public IActionResult OnPost()
		{
			try
			{
				Console.WriteLine("QueryCrudModel: OnPost");

				if(ButtonPressed == "SearchByDropdown")
				{
					SuccessMessage = "Search by Dropdown Successful";
				}
				else if(ButtonPressed == "Add")
				{
					FormValidation();
					Supply.SupplyId = SupplyServices.Add(Supply);
					SuccessMessage = "Add Successful";
				}
				else if(ButtonPressed == "Update")
				{
					FormValidation();
					SupplyServices.Edit(Supply);
					SuccessMessage = "Update Successful";
				}
				else if(ButtonPressed == "Delete")
				{
					SupplyServices.Delete(Supply);
					Supply = new SupplyItem();
					SuccessMessage = "Delete Successful";
				}
				else if(ButtonPressed == "Clear")
				{
					Supply = new SupplyItem();
					SuccessMessage = "Clear Successful";
				}
				else if(Supply.SupplyId != 0)
				{
						Supply = SupplyServices.Retrieve(Supply.SupplyId);
						SuccessMessage = "Retrieve Successful";
				}				
				else 
				{
					ErrorMessage = "Danger: At the end of our ropes!";
				}
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

		private void GetSupplies()
		{
			try
			{
				Console.WriteLine($"QueryCrudModel: GetSupplies");
				if(SelectedJobId == 0)
				{
					SuccessMessage = null;
					throw new Exception("Please Choose a Job");
				}
				SearchedSupplies = SupplyServices.FindSuppliesByJob(SelectedJobId);
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

		public void FormValidation()
		{
			if(string.IsNullOrEmpty(Supply.Material))
				Errors.Add(new Exception("Material"));
			if(Supply.JobId == 0)
				Errors.Add(new Exception("Job"));
			if(Supply.Quantity == 0)
				Errors.Add(new Exception("Quantity"));

			if (Errors.Count() > 0)
					throw new AggregateException("Missing Data: ", Errors);

			if(Supply.Material.Length > 100)
				Errors.Add(new Exception("Material > 100"));
			
			if (Errors.Count() > 0)
					throw new AggregateException("Invalid Data: ", Errors);
		}

	}
}

