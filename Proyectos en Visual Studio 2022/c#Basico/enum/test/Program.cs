

namespace test1
{
    enum Bonus { bajo=500,normal=1000,bueno=1500,extra=3000};
    internal class Program
    {
        static void Main(string[] args)
        {
            Empleado brian = new Empleado(Bonus.bajo, 1550.50);

            Console.WriteLine("ingrese el bonus del empleado:\n1:bajo=500\n2:normal=1000\n3:bueno=1500\n4:extra=3000");

            double counter=0;

            do {
                var bonus = Console.ReadLine();
                switch (bonus)
                {
                    case "bajo":
                        counter++;
                        brian.SALARIO += (double)Bonus.bajo;
                        break;
                    case "normal":
                        counter++;
                        brian.SALARIO += (double)Bonus.normal;
                        break;
                    case "bueno":
                        counter++;
                        brian.SALARIO += (double)Bonus.bueno;
                        break;
                    case "extra":
                        counter++;
                        brian.SALARIO += (double)Bonus.extra;
                        break;
                    case "salario":
                        counter++;
                        var salarios=int.TryParse(Console.ReadLine(),out int nuevosalario);
                        brian.SALARIO = nuevosalario;
                        break;
                    default:
                        counter=0;
                        Console.WriteLine("hai sbagliato tutto Ripetti uaglio");
                        break;
                }
            }while (counter==0);




            Console.WriteLine($"brian tiene un stipendio de {brian.SALARIO}");

        }

        

        class Empleado
        {
            private double _salario, _bonus;
            public double SALARIO
            {
                get { return _salario; }
                set { _salario = value; }
            }

            public Empleado(Bonus bonusEmpleado, double salario)
            {
                _bonus = (double)bonusEmpleado;
                this._salario = salario;
            }


            
        }

    }

}