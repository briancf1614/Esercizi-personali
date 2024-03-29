


//public class MiNodo<T>
//{
//    public T Contenido { get; set; }
//    public MiNodo<T> Proximo { get; set; }

//    public MiNodo(T contenido)
//    {
//        Contenido = contenido;
//        Proximo = null;
//    }
//}

//public class miLinkList<T>
//{
//    public MiNodo<T> Head { get; private set; }

//    public void Add(T datos)
//    {
//        MiNodo<T> nuevisimoNodo = new MiNodo<T>(datos);
//        if (Head == null)
//        {
//            Head = nuevisimoNodo;
//        }
//        else
//        {
//            //qui avviene linteresante ciclo perche current diventa current.proximo
//            MiNodo<T> current = Head;
//            while (current.Proximo != null)
//            {
//                current = current.Proximo; //se current.proximo è null diventa nuovissimoNodo
//            }
//            current.Proximo = nuevisimoNodo;
//        }
//    }

//    public void Muestrame()
//    {
//        MiNodo<T> current = Head;
//        while (current != null)
//        {
//            Console.WriteLine(current.Contenido + " ");
//            current = current.Proximo;
//        }
//        Console.WriteLine();
//    }
//}
//public class Program
//{
//    public static void Main()
//    {
//        miLinkList<string> nuevalista = new miLinkList<string>();
//        nuevalista.Add("holaAmigos");
//        nuevalista.Add("2");
//        nuevalista.Add("3");
//        nuevalista.Add("4");

//        nuevalista.Muestrame();
//    }
//}
