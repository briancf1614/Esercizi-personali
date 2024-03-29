using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using RepositoryPatron.Base.Models;
using RepositoryPatron.Base.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IScuolaRepository,ScuolaRepository>();
var connectionStrings = builder.Configuration.GetConnectionString("repoPatron");
builder.Services.AddDbContext<SchoolDbContext>(options => options.UseMySql(connectionStrings, ServerVersion.AutoDetect(connectionStrings)));


var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    SchoolDbContext context = scope.ServiceProvider.GetRequiredService<SchoolDbContext>();
    context.Database.EnsureCreated();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
