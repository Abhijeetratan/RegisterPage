using Microsoft.EntityFrameworkCore;
using RegisterPage.Models;

var builder = WebApplication.CreateBuilder(args);
//Add Register here
builder.Services.AddDbContext<RegContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dxcConn")));

//Add-Migration "firstmig" , "Update-Database"

// Add services to the container.
builder.Services.AddControllersWithViews();

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