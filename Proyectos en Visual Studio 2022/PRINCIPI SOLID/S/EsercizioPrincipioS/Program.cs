using EsercizioPrincipioS.Business.Services;
using EsercizioPrincipioS.Business.Strategies;
using EsercizioPrincipioS.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddTransient<INotificacionService, EmailNotificacionService>();
builder.Services.AddTransient<ICancelacionService, CancelacionService>();
builder.Services.AddTransient<ICalculadorPenalidadStrategy, PenalidadPlanBasico>();
builder.Services.AddTransient<ICalculadorPenalidadStrategy, PenalidadPlanPro>();
builder.Services.AddTransient<ICalculadorPenalidadStrategy, PenalidadPlanEnterprise>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
