//https://github.com/OmniSharp/omnisharp-vscode/blob/master/debugger-launchjson.md#console-terminal-window

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
// Our Namespaces.
using WestWindSystem;

// Creating Supplier and Product Line but no Products.
//Ex01a();
// Creating Supplier, ProductLine, and Products.
//Ex01b();
// Writing only good Product data to a csv file.
//Ex02a("Ex02.dat");
// Read a csv file of Products and put data into object model if valid.
// Choose to have good or bad data
//Ex02b("Ex02.dat");
//Ex02b("Ex02BAD.dat");
// Write good data from a csv file to a json file
Ex02c("Ex02.dat", "Ex02.json");
// Read a json file that only has good data 
// and put data into object model.
Ex02d("Ex02.json");
// Write good and bad data from a csv file
// buy cull out the bad data and only write
// the good data to a json file.
Ex02c("Ex02BAD.dat", "Ex02ONLYGOOD.json");
// Read a json file that only has good data 
// and put data into object model.
Ex02d("Ex02ONLYGOOD.json");

#region Ex01a
void Ex01a()
{
	try
	{
		Console.WriteLine("Ex01a Program started. Creating Supplier and Product Line but no Products");
		Supplier theSupplier = new Supplier("Robbin's Foods   ", "780-111-2222");
		ProductLine theProductLine = new ProductLine(theSupplier);
		Console.WriteLine(theProductLine.Supplier.ToString());
		Console.WriteLine("Ex01a Program ended");
		Console.WriteLine("");
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Exception in Ex01a: {ex.Message}");
	}
	
}
#endregion
#region Ex01b
void Ex01b()
{
	try
	{
		Console.WriteLine("Ex01b Program started. Creating Supplier, ProductLine, and Products");
		Supplier theSupplier = new Supplier("Robbins Foods", "780-111-2222");
		ProductLine theProductLine = new ProductLine(theSupplier);
		Product theProduct = new Product("Chia", Category.BEVERAGE,"10 boxes X 20 bags", 0, 0, 0, false);
		theProductLine.AddProduct(theProduct);
		theProductLine.AddProduct(new Product("White Cheese",Category.DAIRY, "1 kg pkg", 0, 0, 0, false));
		theProductLine.AddProduct(new Product("Angus Beef",Category.MEAT, "20 - 1 kg tins", 0, 0, 0, false));
		theProductLine.AddProduct(new Product("Blue Cheese",Category.DAIRY, "1 kg pkg", 0, 0, 0, false));

		// Try to add a null product.
		//theProductLine.AddProduct(null);
		// Try to add a product with a empty name.
		//theProductLine.AddProduct(new Product("",Category.BEVERAGE, "1 L pkg", 0, 0, 0, false));
		// Try to add a product with a bad name.
		//theProductLine.AddProduct(new Product("Cok/e",Category.BEVERAGE, "1 L pkg", 0, 0, 0, false));

		Console.WriteLine(theProductLine.Supplier.ToString());
			foreach (Product item in theProductLine.Products)
				Console.WriteLine(item.ToString());
		Console.WriteLine(theProductLine.ToString());
		Console.WriteLine("Ex01b Program ended");
		Console.WriteLine("");
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Exception in Ex01b: {ex.Message}");
	}	
}
#endregion
#region Ex02a
void Ex02a(string csvFileName)
{
	try
	{
		Console.WriteLine("Ex02a Program started. Writing only good product data to a csv file.");
		Console.WriteLine($"Writing data to file: {csvFileName}");
		Supplier theSupplier = new Supplier("Robbins Foods", "780-111-2222");
		ProductLine theProductLine = new ProductLine(theSupplier);
		theProductLine.AddProduct(new Product("Chia", Category.BEVERAGE,"10 boxes X 20 bags", 0, 0, 0, false));
		theProductLine.AddProduct(new Product("White Cheese",Category.DAIRY, "1 kg pkg", 0, 0, 0, false));
		theProductLine.AddProduct(new Product("Angus Beef",Category.MEAT, "20 - 1 kg tins", 0, 0, 0, false));
		theProductLine.AddProduct(new Product("Orange Cheese",Category.DAIRY, "1 kg pkg", 0, 0, 0, false));
		theProductLine.AddProduct(new Product("Aniseed Syrup", Category.BEVERAGE,"12 - 550 ml bottles", 0, 0, 0, false));
		theProductLine.AddProduct(new Product("Milk",Category.DAIRY, "1 L pkg", 0, 0, 0, false));
		
		foreach (var item in theProductLine.Products)
			Console.WriteLine(item.ToString());

		List<string> csvLines = new();
		foreach (var item in theProductLine.Products)
			csvLines.Add(item.ToString());
		//write to a csv file. requires System.IOs    
		File.WriteAllLines(csvFileName, csvLines);
		Console.WriteLine($"Data successfully written to file at: {Path.GetFullPath(csvFileName)}");
		Console.WriteLine("Ex02a Program ended");
		Console.WriteLine("");
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Exception in Ex02a: {ex.Message}");
	}
}
#endregion
#region Ex02b
void Ex02b(string csvFileName)
{
	try
	{
		Console.WriteLine("Ex02b Program started. Read a csv file and put data into object model if valid.");
		Console.WriteLine($"Reading data from file: {csvFileName}");
		Supplier theSupplier = new Supplier("Robbins Foods", "780-111-2222");
		ProductLine theProductLine = new ProductLine(theSupplier);
		//read the csv file and each line becomes a new product added to the product list.
		string[] csvFileInput = File.ReadAllLines(csvFileName);
		Product product = null;
		//each line read from the file is a string that now has to be parsed into different types.
		foreach(string line in csvFileInput)
		{
			try
			{
			bool returnedBool = Product.TryParse(line, out product);
			//This line of code is here only to show that the bool is always returned.
			Console.WriteLine($"returnedBool is: {returnedBool} for: {line}");
			if(returnedBool != false)
				theProductLine.AddProduct(product);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception (Run foreach catch): {ex.Message}");
			}    
		}
		Console.WriteLine(theProductLine.Supplier.ToString());
		foreach (var item in theProductLine.Products)
			Console.WriteLine(item.ToString());
		Console.WriteLine(theProductLine.ToString());
		Console.WriteLine("Ex02b Program ended");
		Console.WriteLine("");
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Exception in Ex02b: {ex.Message}");
	}
}
#endregion
#region Ex02c
void Ex02c(string csvFileName, string jsonFileName)
{
	try
	{
		Console.WriteLine("Ex02c Program started.");
		Console.WriteLine("Taking good data, culling bad data from csv file, and then writing good data to a json file.");
		Console.WriteLine($"Reading data from file: {csvFileName}");
		Supplier theSupplier = new Supplier("Robbins Foods", "780-111-2222");
		ProductLine theProductLine = new ProductLine(theSupplier);
		//read the csv file and each line becomes a new product added to the product list.
		string[] csvFileInput = File.ReadAllLines(csvFileName);
		Product product = null;
		//each line read from the file is a string that now has to be parsed into different types.
		foreach(var line in csvFileInput)
		{
			try
			{
			bool returnedBool = Product.TryParse(line, out product);
			//This line of code is here only to show that the bool is always returned.
			Console.WriteLine($"returnedBool is: {returnedBool} for: {line}");
			if(returnedBool != false)
				theProductLine.AddProduct(product);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception (Run foreach catch): {ex.Message}");
			}    
		}
		JsonSerializerOptions options = new JsonSerializerOptions
		{
			WriteIndented = true,
			IncludeFields = true
		};
		string jsonString = JsonSerializer.Serialize<ProductLine>(theProductLine, options);
		File.WriteAllText(jsonFileName,jsonString);
		Console.WriteLine($"Check out the file at: {Path.GetFullPath(jsonFileName)}");
		Console.WriteLine("Ex02c Program ended");
		Console.WriteLine("");
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Exception in Ex02c: {ex.Message}");
	}   
}
#endregion
#region Ex02d
void Ex02d(string jsonFileName)
{
	try
	{
		Console.WriteLine("Ex02d Program started.");
		Console.WriteLine("Read a json file and put data into object model.");
		Console.WriteLine($"Reading data from file: {jsonFileName}");
		string jsonString = File.ReadAllText(jsonFileName);
		JsonSerializerOptions options = new JsonSerializerOptions
		{
			WriteIndented = true,
			IncludeFields = true
		};
		ProductLine theProductLine = JsonSerializer.Deserialize<ProductLine>(jsonString, options);
		Console.WriteLine(theProductLine.Supplier.ToString());
		foreach (var item in theProductLine.Products)
			Console.WriteLine(item.ToString());
		Console.WriteLine(theProductLine.ToString());
		Console.WriteLine("Ex02d Program ended");
		Console.WriteLine("");
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Exception in Ex02d: {ex.Message}");
	}   
}
#endregion
