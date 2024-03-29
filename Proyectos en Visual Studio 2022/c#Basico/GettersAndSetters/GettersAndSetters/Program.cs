using GettersAndSetters;

Coche coche1 = new Coche(4,30,25);
coche1.setExtras(true,"cuero");
Console.WriteLine(coche1.getInfoCoche());
Console.WriteLine(coche1.getExtras());