// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Personajes;

Personaje nuevoPersonaje;

FabricaDePersonajes fp = new FabricaDePersonajes();
nuevoPersonaje = fp.crearPersonaje();

Console.WriteLine(nuevoPersonaje.Nombre);

