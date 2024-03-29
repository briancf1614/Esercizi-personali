using ConceptosPOO;

//using static System.Math;


//realizarTarea();

double raiz=Math.Sqrt(9);
double potencia=Math.Pow(2,3);
Console.WriteLine($"La raiz de 9 es {raiz}");
Console.WriteLine($"2 elevado a 3 es {potencia}");



//Clase anonima
var miVariable = new { Nombre = "Brian", Edad = 30, Telefono = "123456789" };
Console.WriteLine(miVariable.GetType());
var otraVariable = new { Nombre = "jorge", Edad = 20, Telefono = "98876564332134" };
Console.WriteLine(otraVariable.GetType());
//posso dire questo solo se sono della stessa classe ==Parametri

miVariable = otraVariable;

static void realizarTarea()
{
    Punto origen =new Punto();
    Punto destino = new Punto(128, 80);
    double distancia =origen.distancia(destino);
    Console.WriteLine($"Numero de objetos crados: {Punto.ContadorDeObjetos()}");
}