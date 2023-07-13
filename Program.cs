using Personajes;
using TrabajandoJson;
using RickandMorty;
using Api;
using System.Text.Json;

//crear lista de personajes
FabricaDePersonajes fp = new FabricaDePersonajes();
List<Personaje> listapersonajes = new List<Personaje>();
string? nombreArchivo = "listapersonajes.json";
PersonajesJson HelperJson = new PersonajesJson();

if (!HelperJson.Existe(nombreArchivo))
{
    for (int i = 0; i < 9; i++)
    {
        var personaje = fp.crearPersonaje();

        if (listapersonajes.Contains(personaje))
        {
            i--;
        } else
        {
            listapersonajes.Add(personaje);
        }
    }
    HelperJson.GuardarPersonaje(listapersonajes, nombreArchivo);
} else
{
    listapersonajes = HelperJson.LeerPersonajes(nombreArchivo);
} //controlar
 
List<Personaje> leerarchivo = new List<Personaje>();

leerarchivo = HelperJson.LeerPersonajes(nombreArchivo);

//JUEGOOOOOOO

Console.WriteLine("Bienvenido!!!!");

int elegido;
Console.WriteLine("Elija un personaje: ");

for (int i = 0; i < leerarchivo.Count; i++)
{
    Console.WriteLine(i + "-" + leerarchivo[i].Nombre);
}

bool control = int.TryParse(Console.ReadLine(), out elegido);

if (control)
{
    var personajeElegido = listapersonajes[elegido];
    Console.WriteLine("Su eleccion: " + personajeElegido.Nombre);
    
    do
    {
        



    } while (listapersonajes.Count >= 1);
}




