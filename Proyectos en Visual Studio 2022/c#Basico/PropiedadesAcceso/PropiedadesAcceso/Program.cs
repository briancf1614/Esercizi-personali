

Empleado Brian = new Empleado("Brian");

Brian.SALARIO = -100;
Console.WriteLine("el salario es "+Brian.SALARIO);
class Empleado
{
    private string _nombre;
    private double _salario;

    public Empleado(string nombre)
    {
        this._nombre = nombre;
    }

    //public void setSalario(double salario)
    //{
    //    if (salario < 0)
    //    {
    //        Console.WriteLine("El salario no puede ser negativo. Se asignara 0 como salario");
    //        this.salario = 0;
    //    }
    //    else
    //    {
    //        this.salario = salario;
    //    }
    //}

    //public double getSalario()
    //{
    //    return salario;
    //}


    private double evaluaSalario(double salario)
    {
        if (salario<0) return 0;
        else return salario;
    }
    //PROPERTY
    //public double SALARIO
    //{
    //    get { return this.salario; }
    //    set { this.salario = evaluaSalario(value); }
    //}

    public double SALARIO
    {
        get => this._salario;
        set => this._salario = evaluaSalario(value);
    }

}