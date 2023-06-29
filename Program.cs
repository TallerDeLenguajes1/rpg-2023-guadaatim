// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Personajes;
using System.Text.Json;

//un personaje
Personaje nuevoPersonaje;
FabricaDePersonajes fp = new FabricaDePersonajes();
nuevoPersonaje = fp.crearPersonaje();
//Console.WriteLine(nuevoPersonaje.Nombre);

//lista de personajes
List<Personaje> listapersonajes = new List<Personaje>();
string? nombreArchivo = "listapersonajes.json";
PersonajesJson HelperJson = new PersonajesJson();

if (!HelperJson.Existe(nombreArchivo))
{
    for (int i = 0; i < 9; i++)
    {
        var personajito = fp.crearPersonaje();
        listapersonajes.Add(personajito);
    }
    HelperJson.GuardarPersonaje(listapersonajes, nombreArchivo);
} else
{
    listapersonajes = HelperJson.LeerPersonajes(nombreArchivo);
}
 
List<Personaje> leerarchivo = new List<Personaje>();

leerarchivo = HelperJson.LeerPersonajes(nombreArchivo);

for (int i = 0; i < leerarchivo.Count; i++)
{
    Console.WriteLine(leerarchivo[i].Nombre);
}