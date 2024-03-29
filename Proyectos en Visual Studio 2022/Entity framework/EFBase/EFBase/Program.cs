using EFBase.Models;
using EFBase.Models.Repositories;
using EFBase.Services;
using EfTestBase.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IWorkingExperienceRepository,WorkingExperienceRepository>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<InsertUser>();
var Stringconnections = builder.Configuration.GetConnectionString("Curso");
builder.Services.AddDbContext<CursoDbContext>(options=>options.UseMySql(Stringconnections,ServerVersion.AutoDetect(Stringconnections)));
var app = builder.Build();
//Questo non ho capito ma dice che crea il db in automatico nel caso non ci sia,  ma se rileva tabelle non crea piu niente perche pensa che è tutto a pposto
using(var scope = app.Services.CreateScope())
{
    CursoDbContext context = scope.ServiceProvider.GetRequiredService<CursoDbContext>();
    //context.Database.Migrate();
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
