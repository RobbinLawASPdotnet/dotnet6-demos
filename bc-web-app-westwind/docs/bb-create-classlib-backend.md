# Train Watch - Ex03 - Web Server (Back-End) Setup and Database Access via the About Page

> This is the **second** in a series of exercises where you will be building a website to manage information on trains. **Train Watch** is a community site for train lovers who want to keep up-to-date on trains across North America. They want to maintain a database of Engines and RailCars.
>
> **This set is cumulative**; future exercises in this series will build upon previous exercises.

## Overview

You are to create an additional project for the Entity, DLL, and BLL classes. You will also be creating a new page to test that the database configuration has been set up correctly.

Use the demos presented in class as a guide to implementing this exercise.

---
### Install Database

A new database called [TrainWatch](./TrainWatch.dacpac) has been supplied to you for this exercise. 

Use Microsoft SQL Management Studio to deploy the TrainWatch.dacpac file to the database.

---
### Server (Back-End) Set Up

In this task, you will be creating an additional project for the "back-end" of the application and ensuring your solution follows rudimentary Client-Server architecture.

```csharp
# From the src/ folder
# Create a Class Library which will be the Web Server (Back-End)
dotnet new classlib -n webclasslib -o webclasslib
# Allow the webapp project to use the classlib project by referencing it.
dotnet add webapp/webapp.csproj reference webclasslib/webclasslib.csproj
# Add the project to the solution
dotnet sln "solution.sln" add webclasslib\webclasslib.csproj
```

To ensure that your web application works, build and run your project.

```csharp
# From the src/ folder
cd webapp
dotnet build
dotnet watch run
```
---
### Entity Framework

We will be using the **Microsoft.EntityFrameworkCore.SqlServer** NuGet package to connect to this database. Add this NuGet package to the class library project.

```csharp
# From the src/ folder
cd webclasslib
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
---
### Server Framework

Inside your class library `webclasslib` folder, create three folders: "Entities", "DAL", and "BLL". 

---
### Entities

In the "Entities" folder, create a file called `BuildVersion.cs` and create the appropriate class called `BuildVersion` that models the database `DbVersion` table in the ***TrainWatch*** database. You can use the following ERD to guide your coding, but you should always remember to confirm the model's structure with the actual tables in the database.

![ERD](./img/TrainWatch.png)

Make sure to make the namespace as follows:  `namespace Entities`.

For the `BuildVersion` entity, override the `.ToString()` method to display the version information as a string. Use an appropriate formatting - one that would be suitable for either web or console applications.

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

		public DbSet<BuildVersion> BuildVersions { get; set; }
	}
}
```
---
### BLL Services

In the "BLL" folder of your class library add the file `DbVersionServices.cs` that will hold the class `DbVersionServices`. This class must have a constructor that requires an instance of the `Context` class.

In this class, create a public method called `GetDbVersion()` that has no parameters and returns an instance of the `BuildVersion` entity. The related database table should only have one row, so you can return that first item from the database context.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Additional Namespaces
using DAL;
using Entities;
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
		public BuildVersion GetDbVersion() 
		{
			// You must complete the code here.
		}
		#endregion 
	}
}
```
---
### Register Context and Services In a Backend Extension Class

Inside your class library `webclasslib` folder, create a file called `BackendExtensions.cs`. Copy the following code into the file:

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
var connectionString = builder.Configuration.GetConnectionString("TWDB");
builder.Services.AddBackendDependencies(options =>
    options.UseSqlServer(connectionString));

// This statement is already in the file
var app = builder.Build();
```
---
### Setup Connection String In `appsettings.json`

In addition, you will need to set up the database connection string in the `appsettings.json` file:

```csharp
"ConnectionStrings": {
	"TWDB" : "Server=.;Database=TrainWatch;Integrated Security=true;"
  },
```

If you have a `named instance` for your SQL Server instance you must
replace the `Server=.;` with `Server=instancename;`
---
### Create The `About` Page

Create an `About.cshtml`/`About.cshtml.cs` Razor Page to display the database version information. The Page Model class must declare in its constructor a dependency on the `DbVersionServices` class. 

On this page, display the database version information from the DbVersion table of the database.

```csharp
# From the src/ folder
cd webapp
dotnet new page -n About -o Pages
```

Be sure to add a app bar item so that this page can be navigated to by using the main app bar; use the text "About" for the link.

To ensure that your web application works, build and run your project.

```csharp
# From the src/ folder
cd webapp
dotnet build
dotnet watch run
```
---
### Add HTML and C# to The `About` Page

Use the `About` page presented in the `WestWind` demo as a template
to complete the `About` page in this exercise.

---