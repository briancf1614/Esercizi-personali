//Array implicito

using ArrayImplicito;

var datos = new[] { "Juan", "Pedro", "Luis" };

//objeto
Empleados Ana = new Empleados("Ana", 25);

//array de objetos
Empleados[] arrayEmpleados = new Empleados[3];
  
arrayEmpleados[0]=new Empleados("Juan", 25);
arrayEmpleados[1] = new Empleados("brian", 26);
arrayEmpleados[2] = Ana;

//Array de clases anonimas

var personas = new[]
{
    new{Nombre = "juan",edad=21},
    new{Nombre = "lucas",edad=23},
    new{Nombre = "lopez",edad=35}
};
Console.WriteLine(personas[personas.Length-1]);