

//using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
//using EmployeeRegistration.Models;
//using Microsoft.Extensions.FileProviders;
//var services = new ServiceCollection();
//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddSingleton<IFileProvider>(
//    new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

//var serviceProvider = services.BuildServiceProvider();
//// Add services to the container.

//builder.Services.AddControllersWithViews();
//builder.Services.AddTransient<PdfService>();


//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Employee}/{action=CommonView}/{id?}");

//app.Run();

using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using EmployeeRegistration.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IFileProvider>(
    new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<PdfService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=CommonView}/{id?}");

app.Run();
