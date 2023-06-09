// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Personajes;
using System.Text.Json;

//un personaje
Personaje nuevoPersonaje;
FabricaDePersonajes fp = new FabricaDePersonajes();
nuevoPersonaje = fp.crearPersonaje();
Console.WriteLine(nuevoPersonaje.Nombre);

//lista de personajes
List<Personaje> listapersonajes = new List<Personaje>();

for (int i = 0; i < 9; i++)
{
    listapersonajes.Add(fp.crearPersonaje());
}

//generar 10 personajes y guardarlos