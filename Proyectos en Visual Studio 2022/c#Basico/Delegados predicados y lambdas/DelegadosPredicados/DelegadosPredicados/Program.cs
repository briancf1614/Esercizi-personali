internal class Program
{
    private static void Main(string[] args)
    {
        List<Personas> gente = new List<Personas>();

        Personas P1 = new Personas();
        P1.Nombre= "Juan";
        P1.Edad = 20;

        Personas P2 = new Personas();
        P2.Nombre = "Maria";
        P2.Edad = 10;

        Personas P3 = new Personas();
        P3.Nombre = "Ana";
        P3.Edad = 42;

        gente.AddRange(new Personas[] { P1, P2, P3 });

        Predicate<Personas> predicato = new Predicate<Personas>(ExisteJuan);

        bool existe = gente.Exists(predicato);
        Console.WriteLine("Existe Juan: " + existe);
        if (existe) Console.WriteLine("Existe Juan");
        else Console.WriteLine("No existe Juan");

    }

    static bool ExisteJuan(Personas persona)
    {
        if (persona.Nombre == "Juan") return true;
        else return false;
    }


}

    class Personas
    {
        private string _nombre;
        private int _edad;

        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Edad { get => _edad; set => _edad = value; }
    }


