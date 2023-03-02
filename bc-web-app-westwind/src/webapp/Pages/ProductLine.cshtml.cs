using Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace MyApp.Namespace
{
    public class RoyalFamilyModel : PageModel
    {
        private IWebHostEnvironment WebHostEnvironment;
        public RoyalFamilyModel(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public ProductLine TheProductLine { get; private set; }

        public void OnGet()
        {
            string contextRootPath = WebHostEnvironment.ContentRootPath;
            string jsonFilePath = Path.Combine(contextRootPath, @"Data\ProductLine.json");
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            };
            TheProductLine = JsonSerializer.Deserialize<ProductLine>(jsonString, options);
            Console.WriteLine(TheProductLine.Supplier.ToString());
            foreach (var item in TheProductLine.Products)
                Console.WriteLine(item.ToString());
            Console.WriteLine(TheProductLine.ToString());            
        }
    }
}
