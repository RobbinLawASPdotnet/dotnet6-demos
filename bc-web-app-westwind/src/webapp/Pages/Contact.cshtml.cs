//https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references
//#nullable disable
namespace MyApp.Namespace
{
    public class ContactModel : PageModel
    {
        public string Text1{get;set;}

        [BindProperty] 
        public string Text2{get;set;}
        
        [BindProperty] 
        public string Text3{get;set;}

        public int Number1{get;set;}

        [BindProperty] 
        public int Number2{get;set;}

        [BindProperty] 
        public int Number3{get;set;}

        [BindProperty]
        public string Email{get;set;}

        [BindProperty]
        public DateTime MyDate{get;set;}

        public List<string> SelectListOfSubjects{get;set;}
        [BindProperty]
        public int SelectedSubjectId {get;set;}

        [BindProperty]
        public string MessageBody{get;set;}
        [BindProperty]
        public string CheckBox{get;set;}
        [BindProperty]
        public string Radio{get;set;}
        [BindProperty]
        public string Range{get;set;}

        [BindProperty]
        public string ButtonPressed {get; set;}

        public string SuccessMessage {get; set;}
        public string ErrorMessage {get; set;}
        public List<Exception> errors {get; set;} = new();

        public void OnGet()
        {
                Console.WriteLine($"ContactModel: OnGet");
                PopulateSelectLists();
        }

        public IActionResult OnPost(string text1, string number1)
        {
            try
            {
                Console.WriteLine($"ContactModel: OnPost");
                PopulateSelectLists();
                Text1 = text1;
                if(!string.IsNullOrEmpty(number1))
                    Number1 = int.Parse(number1);

                if(ButtonPressed == "Submit")
                {
                    Console.WriteLine($"checkbox= {CheckBox}");
                    Console.WriteLine($"radio= {Radio}");
                    // Client Side Validation
                    if (string.IsNullOrEmpty(Text1))
                        errors.Add(new Exception("Text1"));
                    if (SelectedSubjectId == 0)
                        errors.Add(new Exception("DropDown"));
                    
                    if (errors.Count() > 0)
                        throw new AggregateException("Missing Data: ", errors);

                    SuccessMessage = $"T1={Text1}, T2={Text2}, T3={Text3}, N1={Number1}, N2={Number2}, N3={Number3}, Email={Email}, Date={MyDate}, Subject={SelectListOfSubjects[SelectedSubjectId]}, Text={MessageBody}, CheckBox={CheckBox}, Radio={Radio}";
                } else if(ButtonPressed == "Clear")
                {
                    SelectedSubjectId = 0;
                    MyDate = DateTime.MinValue;
                    CheckBox = null;
                    Radio = "";
                    SuccessMessage = "Clear Successful";
                    //throw new Exception("Clear button just threw an exception but lucky we caught it.");
                }
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

        private void PopulateSelectLists()
        {
            try
            {
                SelectListOfSubjects = new List<string>(){"select...", "Contributing", "Request Membership", "Bug Report"};  
            }
            catch (Exception e)
            { 
                ErrorMessage = GetInnerException(e);
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