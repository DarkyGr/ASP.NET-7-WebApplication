using Microsoft.EntityFrameworkCore;
using WebApplicationLogin.Models;
using WebApplicationLogin.Services.Contract;
using WebApplicationLogin.Services.Implementation;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Database context configuration
builder.Services.AddDbContext<DbWebapplication01Context>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLString"));
});

// Add classes from our services folder
builder.Services.AddScoped<IUserService, UserService>();

// Cookie Configuration
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(Options =>
    {
        Options.LoginPath = "/Start/Singin";
        Options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

// Clear Cache (Avoid returning once you log out)
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(
            new ResponseCacheAttribute { 
                NoStore = true,
                Location = ResponseCacheLocation.None,
            }
        );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

// Add Authentication
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Start}/{action=Singin}/{id?}");

app.Run();
