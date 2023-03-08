using Microsoft.EntityFrameworkCore;
using Regolo2020.Base;
using Regolo2020.Base.Business;
using Regolo2020.Base.DataModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Controllers
builder.Services.AddControllers().AddJsonOptions(configure => {
    configure.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Get all DbContext types
var assemliesType = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes());
var dbContextTypes = assemliesType.Where(t => t.IsAssignableTo(typeof(DbContext)));

var dbContextOptionsAction = (DbContextOptionsBuilder options) =>
{
    string regoloDbContextConnectionString = builder.Configuration.GetConnectionString("Regolo2020MySqlConnectionString") ?? string.Empty;

    options.UseMySql(regoloDbContextConnectionString, ServerVersion.AutoDetect(regoloDbContextConnectionString));
    options.EnableSensitiveDataLogging();
};

var builderServicesAddDbContextMethod = typeof(EntityFrameworkServiceCollectionExtensions).GetMethod("AddDbContext", 1, new[] {
    typeof(IServiceCollection),
    typeof(Action<DbContextOptionsBuilder>),
    typeof(ServiceLifetime),
    typeof(ServiceLifetime)
});

foreach (var dbContextType in dbContextTypes)
{
    // Register EF Core database contexts.
    builderServicesAddDbContextMethod?.MakeGenericMethod(dbContextType).Invoke(null, new object[] {
        builder.Services,
        dbContextOptionsAction,
        ServiceLifetime.Scoped,
        ServiceLifetime.Scoped
    });

    // LayoutAmbienteSeedData class manager Dependency Injection configuration
    var layoutAmbienteSeedDataServiceType = typeof(ILayoutAmbienteSeedData<>).MakeGenericType(dbContextType);
    foreach (var at in assemliesType)
    {
        if (!at.IsAssignableTo(layoutAmbienteSeedDataServiceType)) continue;
        builder.Services.AddScoped(layoutAmbienteSeedDataServiceType, at);
    }

    // LayoutPageSeedData class manager Dependency Injection configuration
    var layoutPageSeedDataServiceType = typeof(ILayoutPageSeedData<>).MakeGenericType(dbContextType);
    foreach (var at in assemliesType)
    {
        if (!at.IsAssignableTo(layoutPageSeedDataServiceType)) continue;
        builder.Services.AddScoped(layoutPageSeedDataServiceType, at);
    }
}

// Other Dependency Injection configuration
builder.Services.AddScoped<TransactionHelper>();
builder.Services.AddScoped(typeof(IBusinessCrud<,>), typeof(BaseCrudBusiness<,>));

// Base Crud Controller generation based on entity that extends IDataModel
builder.Services
    .AddMvc(o => o.Conventions.Add(new RegoloGenericControllerRouteConvention()))
    .ConfigureApplicationPartManager(m => m.FeatureProviders.Add(new RegoloControllerFeatureProvider()));


var app = builder.Build();

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
