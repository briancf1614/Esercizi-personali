Dictionary<string, int> edades = new Dictionary<string, int>();

//rellenar diccionario 
edades.Add("juan", 25);
edades.Add("Diandra", 35);
edades["Maria"] = 28;
edades["Antonio"] = 30;

//recorrer el diccionario

foreach(KeyValuePair<string,int> persona in edades)
{
    Console.WriteLine($"Nombre: {persona.Key} Edad: {persona.Value}");
}