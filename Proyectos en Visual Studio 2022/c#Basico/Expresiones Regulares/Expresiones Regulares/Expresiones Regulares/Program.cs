using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {

        string frase = "Mi Web es https://www.pildorasinformaticas.es";


        string patron = "https://(www.)?pildorasinformaticas.es";

        Regex miRegex = new Regex(patron);

        MatchCollection elMatch= miRegex.Matches(frase);

        if (elMatch.Count > 0) Console.WriteLine("Se ha encontrado una E");
        else Console.WriteLine("No se ha encontrado una E");


    }




    
}