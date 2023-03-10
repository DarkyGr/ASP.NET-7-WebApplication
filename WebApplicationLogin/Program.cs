using Microsoft.EntityFrameworkCore;
using WebApplicationLogin.Models;
using WebApplicationLogin.Services.Contract;
using WebApplicationLogin.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Database context configuration
builder.Services.AddDbContext<DbWebapplication01Context>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLString"));
});

// Add classes from our services folder
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
