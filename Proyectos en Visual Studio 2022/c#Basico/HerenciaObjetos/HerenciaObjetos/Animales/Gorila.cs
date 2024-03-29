using HerenciaObjetos.Animales;

internal class Gorila:Mamiferos
{
    private string gorila;
    public Gorila(string gorila) : base(gorila)
    {

        this.gorila = gorila;

    }
    public void Trepar()
    {
        Console.WriteLine("Trepar");
    }

    public override void Saltar()
    {
        Console.WriteLine("Soy un gorila y salto entre arboles");
    }
}