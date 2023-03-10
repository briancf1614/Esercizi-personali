using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbpruebaContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnections"),ServerVersion.Parse("iherbafnsdijkfnawijsdksd"));
});

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
