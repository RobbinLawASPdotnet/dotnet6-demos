//using statements added
using Microsoft.EntityFrameworkCore;
using DAL;
using BLL;
using webclasslib;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Get the connection string.
var connectionString = builder.Configuration.GetConnectionString("WWDB");

//Context class as a DbContext using SQL Server
// builder.Services.AddDbContext<Context>(context => context.UseSqlServer(connectionString));

//DbServices class as a transient service
//builder.Services.AddTransient<DbVersionServices>();

// Call the Backend Startup Extension to register services
builder.Services.AddBackendDependencies(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
