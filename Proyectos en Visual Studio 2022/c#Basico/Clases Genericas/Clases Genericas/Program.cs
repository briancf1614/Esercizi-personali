


AlmacenObjetos<Empleado> archivos = new AlmacenObjetos<Empleado>(4);
archivos.agregar(new Empleado(1500));
archivos.agregar(new Empleado(2000));
archivos.agregar(new Empleado(0.25));
archivos.agregar(new Empleado(300));

Empleado empleado=archivos.getElemento(0);
Console.WriteLine(empleado.SALARIO);
class AlmacenObjetos<T>
{
    private T[] _datosElemento;
    private int _i = 0;


    public AlmacenObjetos(int z)
    {
        _datosElemento= new T[z];
    }

    public void agregar(T obj)
    {
        _datosElemento[_i] = obj;
        _i++;
    }

    public T getElemento(int i)
    {
        return _datosElemento[i];
    }
    
}

class Empleado
{
    public double _salario;

    public Empleado(double salario)
    {
        _salario= salario;
    }
    public double SALARIO
    {
        get { return _salario; }
    }
}