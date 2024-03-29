Queue<int> numeros = new Queue<int>();

foreach (int numero in new int[5] {1,2,3,4,5})
{
    numeros.Enqueue(numero);
}
//recorriendo la queue
foreach(int numero in numeros)
{
    Console.WriteLine(numero);
}

//emliminando elementos en queue el priero en entrar
numeros.Dequeue();

foreach(int numero in numeros)
{
    Console.WriteLine(numero);
}