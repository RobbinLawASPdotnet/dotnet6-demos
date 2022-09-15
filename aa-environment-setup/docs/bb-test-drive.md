# First dotnet 6 console program using Visual Studio Code

Create your project as a Console Application (.NET 6). 
Before you can create the new console app the `src` folder must be the working folder.
To achieve this right mouse click on the `src` folder and choose `Open in Integrated Terminal`.
From the terminal when your working directory is `src` type the following commands:

```csharp
# From the src/ folder
dotnet new sln -n Test
dotnet new console -n TestSystem
dotnet sln "Test.sln" add TestSystem\TestSystem.csproj
```

To ensure that your web application works, build and run your project.

```csharp
# From the src/ folder
cd TestSystem
dotnet build
dotnet run
```

The resulting output should be "Hello World".

Alternately you could build and run from the *src/* folder. If you would like to test this out first make sure you are in the *src/* folder and then type `dotnet build "Test.sln"`. At this point, you could continue either with VS Code (type `dotnet run -p TestSystem\TestSystem.csproj` from the *src/* folder) or use VS 2022 by double-clicking the "Test.sln" in windows file explorer.

---

# First dotnet 6 console program using Visual Studio 2022 Community Edition
