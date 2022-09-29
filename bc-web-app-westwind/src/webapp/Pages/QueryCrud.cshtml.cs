using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//Additional namespaces
using BLL;
using Entities;
using ViewModels;

namespace MyApp.Namespace
{
	public class QueryCrudModel : PageModel
	{
		private readonly OtherServices Services;
		private readonly ProductServices ProductServices;
		private readonly CategoryServices CategoryServices;
    private readonly SupplierServices SupplierServices;
		public QueryCrudModel(OtherServices services,
													ProductServices productservices,
													CategoryServices categoryservices,
                          SupplierServices supplierservices)
		{
			Services = services;
			ProductServices = productservices;
			CategoryServices = categoryservices;
			SupplierServices = supplierservices;
		}

		public string SuccessMessage { get; set; }
		public string ErrorMessage { get; set; }
		public List<Exception> Errors {get; set;} = new();
		[BindProperty]
		public string ButtonPressed {get; set;}
		[BindProperty]
		public string FilterType {get;set;}
		[BindProperty]
		public string PartialProductName {get;set;}
		[BindProperty]
		public int? SelectedCategoryId {get;set;}
		[BindProperty]
		public List<ProductList> SearchedProducts { get; set; }
		[BindProperty]
		public ProductItem Product {get;set;} = new();
		[BindProperty]
		public string Discontinued {get;set;} 

		[BindProperty]
		//public List<Category> SelectListOfCatagories {get;set;}
		public List<SelectionList> SelectListOfCatagories {get;set;}
		[BindProperty]
		//public List<Supplier> SelectListOfSuppliers {get;set;}
		public List<SelectionList> SelectListOfSuppliers {get;set;}
		
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

				if(ButtonPressed == "SearchByPartialProductName")
				{
					FilterType = "PartialString";
				}
				else if(ButtonPressed == "SearchByCategory")
				{
					FilterType = "DropDown";
				}
				else if(ButtonPressed == "Add")
				{
					if(Discontinued == "on")
						Product.Discontinued = true;
					else
						Product.Discontinued = false;
					FormValidation();
					Product.ProductId = ProductServices.Add(Product);
					SuccessMessage = "Add Successful";
				}
				else if(ButtonPressed == "Update")
				{
					if(Discontinued == "on")
						Product.Discontinued = true;
					else
						Product.Discontinued = false;
					FormValidation();
					ProductServices.Edit(Product);
					SuccessMessage = "Update Successful";
				}
				else if(ButtonPressed == "Delete")
				{
					ProductServices.Delete(Product);
					Product = new ProductItem();
					SuccessMessage = "Delete Successful";
				}
				else if(ButtonPressed == "Clear")
				{
					Product = new ProductItem();
					SuccessMessage = "Clear Successful";
				}
				else if(Product.ProductId != 0)
				{
						Product = ProductServices.Retrieve(Product.ProductId);
						SuccessMessage = "Product Retrieve Successful";
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
			GetProducts(FilterType);
			return Page();
			
		}

		private void PopulateSelectLists()
		{
			try
			{
				Console.WriteLine("Querymodel: PopulateSelectLists");
				SelectListOfCatagories = CategoryServices.ListCategories();
				SelectListOfSuppliers = SupplierServices.ListSuppliers();
			}
			catch (Exception ex)
			{ 
				ErrorMessage = GetInnerException(ex);
			}
		}

		private void GetProducts(string filterType)
		{
			try
			{
				Console.WriteLine($"QueryCrudModel: GetProducts:filtertype= {filterType}");
				if(filterType == "PartialString")
					SearchedProducts = ProductServices.FindProductsByPartialName(PartialProductName);
				else if(filterType == "DropDown")
					SearchedProducts = ProductServices.FindProductsByCategory(SelectedCategoryId);
			}
			catch (Exception ex)
			{ 
				ErrorMessage = GetInnerException(ex);
			}
		}

		public void FormValidation()
		{
			if(string.IsNullOrEmpty(Product.ProductName))
				Errors.Add(new Exception("ProductName"));
			if(Product.SupplierId == 0)
				Errors.Add(new Exception("SupplierId"));
			if(Product.CategoryId == 0)
				Errors.Add(new Exception("CategoryId"));
			if(string.IsNullOrEmpty(Product.QuantityPerUnit))
				Errors.Add(new Exception("QuantityPerUnit"));

			if(Product.UnitPrice < 0)
				Errors.Add(new Exception("UnitPrice < 0"));
			if(Product.UnitsOnOrder < 0)
				Errors.Add(new Exception("UnitsOnOrder < 0"));

			if (Errors.Count() > 0)
					throw new AggregateException("Invalid Data: ", Errors);

			if(Product.ProductName.Length > 40)
				Errors.Add(new Exception("ProductName > 40"));
			if(Product.QuantityPerUnit.Length > 20)
				Errors.Add(new Exception("QuantityPerUnit > 20"));
			
			if (Errors.Count() > 0)
					throw new AggregateException("Invalid Data: ", Errors);
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

