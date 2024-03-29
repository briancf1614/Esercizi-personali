using HerenciaObjetos.Animales;
using HerenciaObjetos.Interfaces;

Caballo Babieca = new Caballo("My Litle Pony");
Humano Juan =new Humano("Roberto");
Gorila Copito = new Gorila("Gorila Koda");
Mamiferos mamifero =new Mamiferos("Mamifero");


Mamiferos animalBoh = new Caballo("Caballito");
//animalBoh.Saltar();

Mamiferos caballito = new Mamiferos("animal");


//Juan.Saltar();

//Babieca.Respirar();


IAnimalesYDeportes IBabieca = Babieca; 

Console.WriteLine("Numero de patas de Babieca: " + IBabieca.NumeroPatas());


ISaltoConPatas IBabiecaDeportista = Babieca;
Console.WriteLine($"Babieca cuando salta salta solo con {IBabiecaDeportista.NumeroPatas()} patas");