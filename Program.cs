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
    int j = 0;

    for (int i = 0; i < 9; i++)
    {
        var personaje = fp.crearPersonaje();

        foreach (var repetido in listapersonajes)
        {
            if (repetido.Nombre == personaje.Nombre)
            {
                j = 1;
                break;
            }
        }

        if (j == 1)
        {
            i--;
            j = 0;
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


for (int i = 0; i < leerarchivo.Count; i++)
{
    Console.WriteLine(i + "-" + leerarchivo[i].Nombre);
}

Console.WriteLine("Elija un personaje: ");
bool control = int.TryParse(Console.ReadLine(), out elegido);

if (control)
{
    do
    {
        var personajeElegido = listapersonajes[elegido];
        Console.WriteLine("Su personaje: " + personajeElegido.Nombre);
        listapersonajes.Remove(personajeElegido);

        var enemigo = new Personaje();
        enemigo = listapersonajes[fp.NumeroRandom(0, 10)];
        Console.WriteLine("Te enfrentas a: " + enemigo.Nombre);

        //combate
        Console.WriteLine("PELEA!!!");

        do
        {
            int ataque = 0;
            int defensa = 0;
            int efectividad = 0;
            int constanteDeAjuste = 500;
            int danioprovocado = 0;

            
            int turno = fp.NumeroRandom(1, 2);

            if (turno == 1)
            {
                Console.WriteLine("Tu atacas!!!");
                ataque = personajeElegido.Destreza * personajeElegido.Fuerza * personajeElegido.Nivel;
                efectividad = fp.NumeroRandom(1, 101);

                defensa = enemigo.Armadura * enemigo.Velocidad;

                danioprovocado = ((ataque * efectividad) - defensa) / constanteDeAjuste;

                enemigo.Salud -= danioprovocado;
            } else
            {
                Console.WriteLine("Te defiendes!!!");
                ataque = enemigo.Destreza * enemigo.Fuerza * enemigo.Nivel;
                efectividad = fp.NumeroRandom(1, 101);
                
                defensa = personajeElegido.Armadura * personajeElegido.Velocidad;

                danioprovocado = ((ataque * efectividad) - defensa) / constanteDeAjuste;

                personajeElegido.Salud -= danioprovocado;
            }

        } while (personajeElegido.Salud >= 0 && enemigo.Salud >= 0);
        
        if (personajeElegido.Salud <= 0)
        {
            Console.WriteLine("Perdiste!!!");
            Console.WriteLine("Cambia de personaje: ");
            for (int i = 0; i < leerarchivo.Count; i++)
            {
                Console.WriteLine(i + "-" + leerarchivo[i].Nombre);
            }



        }
        
    } while (listapersonajes.Count <= 1);
}




