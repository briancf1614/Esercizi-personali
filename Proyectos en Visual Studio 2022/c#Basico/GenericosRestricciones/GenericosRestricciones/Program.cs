



//class AlmacenEmpleados<T> where T : class, new(){ }
//class AlmacenEmpleados<T> where T : Enum
using System.Security.Cryptography.X509Certificates;



AlmacenEmpleados<Estudiante> empleados = new AlmacenEmpleados<Estudiante>(3);
empleados.agregarEmpleados(new Estudiante(2500));
empleados.agregarEmpleados(new Estudiante(1500));
empleados.agregarEmpleados(new Estudiante(3500));


class AlmacenEmpleados<T> where T : IEmpleados
{
    private int i = 0;
    private T[] _datosEmpleado;
    public AlmacenEmpleados(int z)
    {
        _datosEmpleado = new T[z];
    }
    public void agregarEmpleados(T empleado)
    {
        _datosEmpleado[i] = empleado;
        i++;
    }

    public T getEmpleado(int i)
    {
        return _datosEmpleado[i];
    }

    
}



class Director:IEmpleados
{
    private double _salario;
    public Director(double salario)
    {
        this._salario = salario;
    }

    public double getSalario()
    {
        return _salario;
    }
}

class Secretaria:IEmpleados
{
    private double _salario;

    public Secretaria(double salario)
    {
        this._salario = salario;
    }

    public double getSalario()
    {
        return _salario;
    }
}

class Electricista:IEmpleados
{
    private double _salario;
    public Electricista(double salario)
    {
        this._salario = salario;
    }

    public double getSalario()
    {
        return _salario;
    }
}
class Estudiante
{
    private double _edad;
    public Estudiante(double edad)
    {
        this._edad = edad;
    }
    public double getEdad()
    {
        return _edad;
    }
}
interface IEmpleados
{
    double getSalario();
}