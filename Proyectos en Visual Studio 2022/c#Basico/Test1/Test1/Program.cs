


using Test1.classi;

var ejemplo = new Eswitch();

ejemplo.eswitch();
ejemplo.eswitchUsandoParenesisEVariabili();


Console.WriteLine("adesso scegli un numero dal 1 al 12");
var data = Convert.ToInt16(Console.ReadLine());
var eswitch = data switch
{
    1 => "Gennaio",
    2 => "Febbraio",
    3 => "Marzo",
    4 => "Aprile",
    5 => "Maggio",
    6 => "Giugno",
    7 => "Luglio",
    8 => "Agosto",
    9 => "Settembre",
    10 => "Ottobre",
    11 => "Novembre",
    12 => "Dicembre",
    _ => "Mese non valido"
};
Console.WriteLine(eswitch);
Console.ReadLine();

/*var input =Convert.ToString(Console.ReadLine());
switch (input)
{
    case "apple":
        Console.WriteLine(1);
        break;
    case "banana":
        Console.WriteLine(2);
        break;
    case "orange":
        Console.WriteLine("hola");
        break;
    default:
        Console.WriteLine("Unknown fruit");
        break;
}
*/