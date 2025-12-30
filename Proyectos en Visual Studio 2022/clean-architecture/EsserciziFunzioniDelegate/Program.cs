List<double> preciosSinIva = new List<double> { 10.0, 20.0, 50.0 };

var a = preciosSinIva.Select(precios => precios + CalcularIva(precios)).ToList();

// pura perche non modifico niente del esterno?
double CalcularIva(double precio)
{
    return precio * 0.21;
}


Predicate<string> utenteValido = nome => nome.Length > 3;

Func<string, string> generatoreToken = nome => "TOKEN-" + nome;

Action<string> LogAccesso = token => Console.WriteLine($"Acceso concedido. Su token es: {token}");


if (utenteValido("Mario"))
{
    string token = generatoreToken("Mario");
    LogAccesso(token);
}

 static string ProcesadorDeTexto(string texto, Func<string, string> operacion)
{
    return operacion(texto);
}
var grito = ProcesadorDeTexto("hola", texto => texto.ToUpper());

var limpieza = ProcesadorDeTexto("    muchos espacios     ", t => t.Trim());

// esemplare di programmazione IMPERATIVA in quanto non gli sto dicendo io di ciclare o fare a manina logica