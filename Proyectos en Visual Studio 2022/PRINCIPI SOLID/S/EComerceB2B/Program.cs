using EComerceB2B.Business;
using EComerceB2B.Business.Strategies;
using EComerceB2B.Domain;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// Registramos todas las "S" (Responsabilidades Únicas)
services.AddTransient<IDescuentoStrategy, DescuentoVipStrategy>();
services.AddTransient<IDescuentoStrategy, DescuentoMayoristaStrategy>();
services.AddTransient<IDescuentoStrategy, DescuentoPrimeraCompraStrategy>();

// Registramos el motor principal
services.AddTransient<IMotorPrecios, MotorDePrecios>();

var serviceProvider = services.BuildServiceProvider();

// 2. Ejecución
var motor = serviceProvider.GetRequiredService<IMotorPrecios>();

var pedidoPrueba = new Pedido
{
    Subtotal = 1500m,
    EsPrimeraCompra = false,
    Cliente = new Cliente { Nombre = "Juan Experto", Tipo = TipoCliente.VIP }
};

decimal totalFinal = motor.ObtenerTotalFinal(pedidoPrueba);

Console.WriteLine($"--- REPORTE DE PRECIOS ---");
Console.WriteLine($"Subtotal Original: ${pedidoPrueba.Subtotal}");
Console.WriteLine($"Total con mejor descuento aplicado: ${totalFinal}");