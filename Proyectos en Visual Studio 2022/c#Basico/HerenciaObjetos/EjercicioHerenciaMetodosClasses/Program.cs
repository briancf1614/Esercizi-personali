







using EjercicioHerenciaMetodosClasses.Clases;

Coche pandinoRosso = new Coche("Fiat");

pandinoRosso.Conducir();

Vehiculo[] arrayCoches = new Vehiculo[4]
{
    new Coche("alfaromeo"),
    new Coche("audi"),
    new Avion(true),
    new Avion(false),
};

arrayCoches[0].Conducir();
arrayCoches[2].Conducir();
((Avion)arrayCoches[3]).soyAvionXd();

var pippo = (Avion)arrayCoches[3];


