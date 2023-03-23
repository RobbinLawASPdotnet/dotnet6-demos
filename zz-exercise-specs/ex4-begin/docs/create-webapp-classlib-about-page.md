# Create a Front-End Web App and a Back-End Class Library

### Links

- [The .net new templates](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new)

---

### Install the database

In the docs folder is a `.bacpac` file that is the compressed database.

Use the Microsoft SQL Server Management Studio tool to install the database.

### Create the Project Templates

We will create (.NET Core 6):
- a class library project to contain our classes, 
- and a web app project that uses the class library code.

Before you begin the `src` folder must be the working folder.
To achieve this right mouse click on the `src` folder and choose `Open in Integrated Terminal`.
From the terminal when your working directory is `src` type the following commands:

```csharp
# From the src/ folder
# Create a class library project template which will be the Back-End.
dotnet new classlib -n Classlib --framework net6.0
# Create a Razor Pages Web Application which will be the Front-End
dotnet new webapp -n WebApp --framework net6.0
# Allow the WebApp project to use the Classlib project by referencing it.
dotnet add WebApp/WebApp.csproj reference Classlib/Classlib.csproj
# Create a sln file and add all projects to it.
dotnet new sln -n App
dotnet sln "App.sln" add Classlib\Classlib.csproj
dotnet sln "App.sln" add WebApp\WebApp.csproj
```
In all .csproj files comment out the following:
```csharp
<!-- <Nullable>enable</Nullable> -->
```

To ensure that your web application works, build and run your project.

```csharp
# From the src/ folder
dotnet build "App.sln"
cd WebApp
dotnet watch run
```

A browser window should open (https://localhost:5001). If you get a certificate error, you need to create a self-signed certificate for your developer machine by typing the following (read more on this [Microsoft Docs page](https://docs.microsoft.com/aspnet/core/security/enforcing-ssl#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos)).

```csharp
dotnet dev-certs https --trust
```
---
### Entity Framework

We will be using the **Microsoft.EntityFrameworkCore.SqlServer** NuGet package to connect to this database. Add this NuGet package to the class library project.

```csharp
# From the src/ folder
cd Classlib
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
---
### Back-End Structure

Inside your class library `Classlib` folder, create four folders: "Entities", "DAL", "ViewModels", and "BLL". 

---
### Entities

In the "Entities" folder, create a file called `DbVersion.cs` and create the appropriate class called `DbVersion` that models the database `DbVersion` table in the database. 

Make sure to make the namespace as follows:  `namespace Entities`.

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
  // The Table("TableName") must be the name of the database table.
  // It may or may not be the same as the class name DbVersion.
	[Table("DbVersion")]
	public partial class DbVersion
	{
		[Key]
		public int Id { get; set; }
		public int Major { get; set; }
		public int Minor { get; set; }
		public int Build { get; set; }
		[Column(TypeName = "datetime")]
		public DateTime ReleaseDate { get; set; }
	}
}

```
---

### DAL Context

In the "DAL" folder, create a file called `Context.cs` which will contain the `Context` class and ensure it inherits from `DbContext`:

```csharp
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Additional Namespaces
using Entities;

namespace DAL 
{
	public class Context : DbContext 
	{
		public Context(DbContextOptions<Context> options)
			: base(options) {}

		public DbSet<DbVersion> DbVersions { get; set; }
	}
}
```
---
### View Models

In the "ViewModels" folder, create a file called `DbVersionView.cs` and create the appropriate class called `DbVersionView`. 

Make sure to make the namespace as follows:  `namespace ViewModels`.

For the `DbVersionView` view model, override the `.ToString()` method to display the version information as a string. Use an appropriate formatting - one that would be suitable for either web or console applications.

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ViewModels
{
	public class DbVersionView
	{
		public int Id { get; set; }
		public int Major { get; set; }
		public int Minor { get; set; }
		public int Build { get; set; }
		public DateTime ReleaseDate { get; set; }

		public override string ToString() 
		{
			return $"Id: {Id}, Major: {Major}, Minor: {Minor}, Build: {Build}, Release Date: {ReleaseDate}";
		}
	}
}

```
---

### BLL Services

In the "BLL" folder of your class library add the file `DbVersionServices.cs` that will hold the class `DbVersionServices`. This class must have a constructor that requires an instance of the `Context` class.

In this class, create a public method called `GetDbVersion()` that has no parameters and returns an instance of the `BuildVersionView` view model. The related database table should only have one row, so you can return that first item from the database context.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Additional Namespaces
using DAL;
using ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BLL 
{
	public class DbVersionServices 
	{
		#region Constructor Dependency Injection
		private readonly Context Context;
		public  DbVersionServices(Context context) 
		{
				if (context == null)
						throw new ArgumentNullException();
				Context = context;
		}
		#endregion

		#region Queries
		public DbVersionView GetDbVersion() 
		{
			Console.WriteLine($"DbServices: GetDbVersion;");
			List<DbVersionView> info = 
			Context.DbVersions
			.Select(x => new DbVersionView
			{
				Id = x.Id,
				Major = x.Major,
				Minor = x.Minor,
				Build = x.Build,
				ReleaseDate = x.ReleaseDate
			})
			.ToList();
			return info.First();
		}
		#endregion 
	}
}
```
---
### Register Context and Services In a Backend Extension Class

Inside your class library `Classlib` folder, create a file called `BackendExtensions.cs`. Copy the following code into the file:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Additional Namespaces
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DAL;
using BLL;

namespace webclasslib
{
	public static class BackendExtensions
	{
		public static void AddBackendDependencies(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
		{	
			services.AddDbContext<Context>(options);

			services.AddTransient<DbVersionServices>((serviceProvider) =>
			{
				var context = serviceProvider.GetRequiredService<Context>();
				return new DbVersionServices(context);
			});
		}
	}
}
```
---
### Reference Backend Extension Class in webapp `Program.cs`

In the Program.cs file include the following:

```csharp
//using statements added
using Microsoft.EntityFrameworkCore;
using DAL;
using BLL;
using webclasslib;
using System.Configuration;

// This statement is already in the file
builder.Services.AddRazorPages();

// Add these two statements immediately after builder.Services.AddRazorPages();
var connectionString = builder.Configuration.GetConnectionString("DB");
builder.Services.AddBackendDependencies(options =>
    options.UseSqlServer(connectionString));

// This statement is already in the file
var app = builder.Build();
```
---
### Setup Connection String In `appsettings.json`

In addition, you will need to set up the database connection string in the `appsettings.json` file.

The `DATABASENAME` is the actual name of the database you are trying to connect to.

```csharp
"ConnectionStrings": {
	"DB" : "Server=.;Database=DATABASENAME;Integrated Security=true; Trust Server Certificate=true"
  },
```

If you have a `named instance` for your SQL Server instance you must
replace the `Server=.;` with `Server=COMPUTERNAME\SQLSERVERINSTANCENAME;`

For example `Server=ANTONIO-PC\\SQLEXPRESS` where the `COMPUTERNAME` is `ANTONIO-PC` and the `SQLSERVERINSTANCENAME` is `\SQLEXPRESS`.

```csharp
"ConnectionStrings": {
	"DB" : "Server=ANTONIO-PC\\SQLEXPRESS;Database=Renos;Integrated Security=true; Trust Server Certificate=true"
  },
```

To find your `COMPUTERNAME` you have to look in the `system` info.

To find your `SQLSERVERINSTANCENAME` you have to look at the service name in the Computer Management App, for example the service called `SQL SERVER (MSSQLSERVER)` is the `default instance` and this is when you can use `Server=.;`

---
### Create The `About` Page

Create an `About.cshtml`/`About.cshtml.cs` Razor Page to display the database version information.

On this page, display the database version information from the DbVersion table of the database.

```csharp
# From the src/ folder
cd WebApp
dotnet new page -n About -o Pages
```

Be sure to add a app bar item in the `_Layout.cshtml` file, so that this page can be navigated to by using the main app bar; use the text "About" for the link.

---
### Add HTML and C# to The `About` Page

Here is the `About.cshtml` presentation page.

```csharp
@page
@model MyApp.Namespace.AboutModel
@{
	ViewData["Title"] = "About";
}

<h5>About The Database Used for This Site</h5>

@if(!string.IsNullOrEmpty(Model.ErrorMessage))
{
	<p style="color:red; font-weight: bold;">@Model.ErrorMessage</p>
}

@if(!string.IsNullOrEmpty(Model.SuccessMessage))
{
	<p style="color:green; font-weight: bold;">@Model.SuccessMessage</p>
}

<table class="table table-hover">
	<tr>
		<th>Database's Version</th>
	</tr>
	<tr>
		@if(Model.DatabaseVersion != null){
			<td>@Model.DatabaseVersion.ToString()</td>
		}
	</tr>
</table>

```

Here is the `About.cshtml.cs` code behind page.

The Page Model class must declare in its constructor a dependency on the `DbVersionServices` class. 

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Additional Namespaces
using ViewModels;
using BLL;

namespace MyApp.Namespace
{
	public class AboutModel : PageModel
	{
		private readonly DbVersionServices Services;
		public AboutModel(DbVersionServices services) {
		   Services = services;
		}

		public DbVersionView DatabaseVersion { get; set; }

		public string SuccessMessage {get; set;}
		public string ErrorMessage {get; set;}

		public void OnGet()
		{
			try
			{
				Console.WriteLine($"AboutModel: OnGet");
				DatabaseVersion = Services.GetDbVersion();
				Console.WriteLine($"XXXXXXXXXXXXXXXXXXX: {DatabaseVersion.ToString()}");
				SuccessMessage = $"Database Retrieve Successful";
			}
			catch (Exception ex)
			{
				ErrorMessage = GetInnerException(ex);
			}
			
		}

		public string GetInnerException(Exception ex)
		{
			Exception rootCause = ex;
			while (rootCause.InnerException != null)
				rootCause = rootCause.InnerException;
			return rootCause.Message;
		}
	}
}
```
---

To ensure that your web application works, build and run your project.

```csharp
# From the src/ folder
cd WebApp
dotnet build
dotnet watch run
```
