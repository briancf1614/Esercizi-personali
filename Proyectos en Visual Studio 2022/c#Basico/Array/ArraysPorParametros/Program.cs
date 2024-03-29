



//int[] numeros = new int[4];
//numeros[0] = 0;
//numeros[1] = 1;
//numeros[2] = 2;
//numeros[3] = 3;
//ProcesaDatos(numeros);


foreach (var dato in LeerDatos())
{
    Console.WriteLine(dato);
}










static void ProcesaDatos(int[] datos)
{
    foreach (var i in datos)
    {
        Console.WriteLine(i);
    }
}


static int[] LeerDatos()
{
    Console.WriteLine("Dime cuantos numeros quieres");
    int numero = int.Parse(Console.ReadLine());

    int[] numeros = new int[numero];

    for (int i = 0; i < numero; i++)
    {
        Console.WriteLine($"dime el valor que tendra la posicion {i}");
        numeros[i] = int.Parse(Console.ReadLine());
    }
    return numeros;
}