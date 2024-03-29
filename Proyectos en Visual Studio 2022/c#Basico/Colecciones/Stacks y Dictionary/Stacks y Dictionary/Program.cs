Stack<int> numeros = new Stack<int>();

foreach (int numero in new int[] {10,11,12,13,14})
{
    numeros.Push(numero);
}

foreach (int numero in numeros)
{
    Console.WriteLine(numero);
}

numeros.Pop();

foreach (int numero in numeros)
{
    Console.WriteLine(numero);
}