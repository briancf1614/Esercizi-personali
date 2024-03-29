

public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class CustomLinkedList<T>
{
    public Node<T> Head { get; private set; }

    // Agregar un elemento al final de la lista
    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            //qui avviene linteresante ciclo perche current diventa current.proximo
            Node<T> current = Head;
            while (current.Next != null)
            {
                current = current.Next;//se current.proximo è null diventa nuovissimoNodo
            }
            current.Next = newNode;
        }
    }

    // Eliminar el primer elemento con el valor especificado
    public void Remove(T data)
    {
        if (Head == null)
        {
            return;
        }
        if (Head.Data.Equals(data))
        {
            Head = Head.Next;
            return;
        }
        Node<T> current = Head;
        while (current.Next != null)
        {
            if (current.Next.Data.Equals(data))
            {
                current.Next = current.Next.Next;
                return;
            }
            current = current.Next;
        }
    }

    // Mostrar todos los elementos en la lista
    public void Display()
    {
        Node<T> current = Head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        // Crear una linked list personalizada
        CustomLinkedList<string> linkedList = new CustomLinkedList<string>();

        // Agregar elementos
        linkedList.Add("hola1");
        linkedList.Add("hola2");
        linkedList.Add("hola3");

        // Mostrar la lista: 1 2 3
        linkedList.Display();

        // Eliminar un elemento
        linkedList.Remove("hola");

        // Mostrar la lista después de eliminar: 1 3
        linkedList.Display();
    }
}

//using System.Text.Json.Nodes;

//LinkedList<string> miLista = new LinkedList<string>();

//miLista.AddLast("hola");
//miLista.AddLast("hola2");
//miLista.AddLast("hola3");

////qui succede lo stesso di sopra,ma usiamo la classe originale
//for(LinkedListNode<string> nodito=miLista.First; nodito!=null; nodito= nodito.Next)
//{
//    string palabra = nodito.Value;
//    Console.WriteLine(palabra);
//}

