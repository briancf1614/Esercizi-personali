internal class Program
{
    //Delegado
    public delegate int OperacionMatematica(int numero1, int numer2);
    private static void Main(string[] args)
    {
        Personas P1 = new Personas();
        P1.NOMBRE = "Juan";
        P1.EDAD = 20;

        Personas P2 = new Personas();
        P2.NOMBRE = "Pedro";
        P2.EDAD = 20;

        //preparazione del delegado
        ComparaPersonas comparador = (persona1, persona2) => persona1 == persona2 ;


        Console.WriteLine(comparador(P1.EDAD, P2.EDAD));

    }

    public delegate bool ComparaPersonas(int edad1, int edad2);

}


class Personas
{
    private string _nombre;
    private int _edad;

    public string NOMBRE { get => _nombre; set => _nombre = value; }
    public int EDAD { get => _edad; set => _edad = value; }
}