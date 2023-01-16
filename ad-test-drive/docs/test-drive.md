# Using Visual Studio Code and the Terminal

We will create (.NET 6):
- a class library project to contain our classes, 
- an xunit tests project to test our code with unit tests,
- and a console project that uses the class library code.

Before you begin the `src` folder must be the working folder.
To achieve this right mouse click on the `src` folder and choose `Open in Integrated Terminal`.
From the terminal when your working directory is `src` type the following commands:

```csharp
# From the src/ folder
# Create a class library project template.
dotnet new classlib -n classlib --framework net6.0
# Create a xunit project template.
dotnet new xunit -n tests --framework net6.0
# Allow the xunit project to use the classlib project by referencing it.
dotnet add tests/tests.csproj reference classlib/classlib.csproj
# Create a console project template.
dotnet new console -n console --framework net6.0 
# Allow the console project to use the classlib project by referencing it.
dotnet add console/console.csproj reference classlib/classlib.csproj
# Create a sln file to optionally use VS Studio
dotnet new sln -n app
dotnet sln "app.sln" add classlib\classlib.csproj
dotnet sln "app.sln" add tests\tests.csproj
dotnet sln "app.sln" add console\console.csproj
```

To ensure that your web application works, build and run your project.

```csharp
# From the src/ folder
cd ConsoleApp
dotnet build
dotnet run
```

The resulting output should be "Hello World".

Alternately you could build and run from the *src/* folder. If you would like to test this out first make sure you are in the *src/* folder and then type `dotnet build "app.sln"`. At this point, you could continue either with VS Code (type `dotnet run -p console\console.csproj` from the *src/* folder) or use VS 2022 by double-clicking the "app.sln" in windows file explorer.

---

