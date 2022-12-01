using BlazorServerCRUD.UI.Data;
using BlazorServerCRUD.UI.Interfaces;
using BlazorServerCRUD.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Configuration;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IFilmService, FilmService>();

// Add Database connection to the container as 'singleton' service
var connectionString = builder.Configuration.GetConnectionString("SqlConnection"); // This connectionString is defined in the 'appsettings.json' file
var sqlConfiguration = new SqlConfiguration(connectionString);
builder.Services.AddSingleton(sqlConfiguration);

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
