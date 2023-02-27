# Web Client (Front-End) Setup and Form Input via the Contact Page

## Overview

You are to create a new ASP.NET Core Web Application (Razor Pages) for this exercise.

Before you begin the `src` folder must be the working folder.
To achieve this right mouse click on the `src` folder and choose `Open in Integrated Terminal`.
From the terminal when your working directory is `src` type the following commands:

```csharp
# From the src/ folder
# Create a Razor Pages Web Application which will be the Front-End
dotnet new webapp -n WebApp --framework net6.0
# Create a sln file and add all projects to it.
dotnet new sln -n App
# Add the webapp project to the solution
dotnet sln "App.sln" add WebApp\WebApp.csproj
```
In all .csproj file comment out the following:
```csharp
<!-- <Nullable>enable</Nullable> -->
```

To ensure that your web application works, build and run your project.

```csharp
# From the src/ folder
cd WebApp
dotnet build
dotnet watch run
```

A browser window should open (https://localhost:5001). If you get a certificate error, you need to create a self-signed certificate for your developer machine by typing the following (read more on this [Microsoft Docs page](https://docs.microsoft.com/aspnet/core/security/enforcing-ssl#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos)).

```csharp
dotnet dev-certs https --trust
```

### Modify `Index.cshtml`

Modify the home page to include the following.

```html
<h2>Hi there</h2>
```

### Update the `_Layout.cshtml`

Ensure that the menu navigation has the following items.

- A link to the home page (`/Index`) with the text "Home"
- A link to the contact page (`/Contact`) with the text "Contact"
- A link to the privacy page (`/Privacy`) with the text "Privacy"

### Add `Contact` Page

Create an `Contact.cshtml`/`Contact.cshtml.cs` Razor Page.

```csharp
# From the src/ folder
cd WebApp
dotnet new page -n Contact -o Pages
```
To ensure that your web application works, build and run your project.

```csharp
# From the src/ folder
cd WebApp
dotnet build
dotnet watch run
```