
//definicion Delegado

internal class Program
{
    //Creo el delegate il quale consiste in un metodo con una stringa dentro
    delegate void MiCarissimoDelegato(string msj);
    private static void Main(string[] args)
    {

        //istanzio el delegate
        MiCarissimoDelegato ElDelegato = new MiCarissimoDelegato(MensajeBienvenida.SaludoBienvenida);
        ElDelegato("Hola amigossss");
        ElDelegato = new MiCarissimoDelegato(MensajeDespedida.SaludoDespedida);
        ElDelegato("Chau amigossss");
    }

}



class MensajeBienvenida
{
    public static void SaludoBienvenida(string msj)
    {
        Console.WriteLine($"es es el mensaje de Bienvenida: {msj}");
    }
}
class MensajeDespedida
{
    public static void SaludoDespedida(string msj)
    {
        Console.WriteLine($"es es el mensaje de Despedida: {msj}");
    }

}