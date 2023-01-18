# Using Visual Studio Code and the Terminal

## Links

- [Using .net and VsCode to unit test](https://www.codemag.com/Article/2009101/Interactive-Unit-Testing-with-.NET-Core-and-VS-Code)
- [The .net new templates](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new)

---

## Instructions

We will create (.NET 6):
- a class library project to contain our classes, 
- an mstest or xunit project to test our code with unit tests, that uses the class library code.
- and a console project that uses the class library code.

Before you begin the `src` folder must be the working folder.
To achieve this right mouse click on the `src` folder and choose `Open in Integrated Terminal`.
From the terminal when your working directory is `src` type the following commands:

```csharp
# From the src/ folder
# Create a class library project template.
dotnet new classlib -n Classlib --framework net6.0
# Create a mstest project template.
dotnet new mstest -n Tests --framework net6.0
# Create a xunit project template. ONLY DO THIS OR THE PREVIOUS NOT BOTH.
dotnet new xunit -n Tests --framework net6.0
# Allow the Tests project to use the classlib project by referencing it.
dotnet add Tests/Tests.csproj reference Classlib/Classlib.csproj
# Create a console project template.
dotnet new console -n Console --framework net6.0 
# Allow the console project to use the classlib project by referencing it.
dotnet add Console/Console.csproj reference Classlib/Classlib.csproj
# Create a sln file to optionally use VS Studio
dotnet new sln -n App
dotnet sln "App.sln" add Classlib\Classlib.csproj
dotnet sln "App.sln" add Tests\Tests.csproj
dotnet sln "App.sln" add Console\Console.csproj
```

To ensure that your web application works, build and run your project.

```csharp
# From the src/ folder
cd Console
dotnet build
dotnet run
```

The resulting output should be `Hello, World!`.

Alternately you could build and run from the *src/* folder. If you would like to test this out first make sure you are in the *src/* folder and then type `dotnet build "App.sln"`. At this point, you could continue either with VS Code (type `dotnet run --project Console\Console.csproj` from the *src/* folder) or use VS 2022 by double-clicking the `App.sln` in the windows file explorer.

---

