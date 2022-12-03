using BlazorServerCRUD.UI.Data;
using BlazorServerCRUD.UI.Interfaces;
using BlazorServerCRUD.UI.Services;
using ElectronNET.API;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// RSV. Electron.NET -- BEGIN
builder.Services.AddElectron();
builder.WebHost.UseElectron(args);
if (HybridSupport.IsElectronActive)
{
    // Open the Electron-Window here
    Task.Run(async () => {
        var window = await Electron.WindowManager.CreateWindowAsync();
        window.OnClosed += () => {
            Electron.App.Quit();
        };
    });
}
// RSV. Electron.NET -- END

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IFilmService, FilmService>();

// Add Database connection to the container as 'singleton' service
var connectionString = builder.Configuration.GetConnectionString("SqlConnection"); // This connectionString is defined in the 'appsettings.json' file

builder.Services.AddDbContext<BlazorServerCRUDContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<BlazorServerCRUDContext>();
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
app.UseAuthentication();;

app.Run();
