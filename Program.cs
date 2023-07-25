using Personajes;
using TrabajandoJson;
using RickandMorty;
using Api;
using Imagenes;
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        //crear lista de personajes
        FabricaDePersonajes fp = new FabricaDePersonajes();
        List<Personaje> listapersonajes = new List<Personaje>();
        string? nombreArchivo = "listapersonajes.json";
        PersonajesJson HelperJson = new PersonajesJson();

        if (!HelperJson.Existe(nombreArchivo))
        {
            int j = 0;

            for (int i = 0; i < 10; i++)
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
                }
                else
                {
                    listapersonajes.Add(personaje);
                }
            }
            HelperJson.GuardarPersonaje(listapersonajes, nombreArchivo);
        }
        else
        {
            listapersonajes = HelperJson.LeerPersonajes(nombreArchivo);
        } //controlar

        List<Personaje> leerarchivo = new List<Personaje>();

        leerarchivo = HelperJson.LeerPersonajes(nombreArchivo);

        //juego
        figuras HelperImagenes = new figuras();

        HelperImagenes.Circulo();
        Console.WriteLine("Bienvenido!!!!");

        int elegido;

        MostrarPersonajes(leerarchivo);

        Console.WriteLine("Elija un personaje: ");
        bool control = int.TryParse(Console.ReadLine(), out elegido);

        if (control)
        {
            var personajeElegido = listapersonajes[elegido];
            listapersonajes.Remove(personajeElegido);

            do
            {
                Console.WriteLine("Su personaje: " + personajeElegido.Nombre);

                var enemigo = new Personaje();
                enemigo = listapersonajes[fp.NumeroRandom(0, listapersonajes.Count - 1)];
                Console.WriteLine("Te enfrentas a: " + enemigo.Nombre);

                //combate
                Console.WriteLine("PELEA!!!");

                do
                {
                    int turno = fp.NumeroRandom(1, 2);

                    if (turno == 1)
                    {
                        Pelea(personajeElegido, enemigo);
                    }
                    else
                    {
                        Pelea(enemigo, personajeElegido);
                    }

                } while (personajeElegido.Salud >= 0 && enemigo.Salud >= 0);

                if (personajeElegido.Salud <= 0)
                {
                    Console.WriteLine("-------Perdiste!!!-------");
                    HelperImagenes.Perdedor();

                    Console.WriteLine("Cambia de personaje: ");
                    enemigo.Salud += 10;

                    int i = 0;
                    Console.WriteLine("Elige: ");
                    foreach (var elegir in listapersonajes)
                    {
                        Console.WriteLine(i + "-" + elegir.Nombre);
                        i++;
                    }

                    control = int.TryParse(Console.ReadLine(), out elegido);

                    if (control)
                    {
                        personajeElegido = listapersonajes[elegido];
                        listapersonajes.Remove(personajeElegido);

                    }
                    else
                    {
                        Console.WriteLine("Error. No se ingreso un numero");
                    }
                }
                else
                {
                    Console.WriteLine("-------Ganaste!!!-------");
                    HelperImagenes.Ganador();
                    Console.WriteLine("Sigue asi!!!");
                    listapersonajes.Remove(enemigo);
                }

            } while (listapersonajes.Count > 1);

            if (listapersonajes.Count == 1)
            {
                if (personajeElegido == listapersonajes[0])
                {
                    Console.WriteLine("FELICIDADES" + listapersonajes[0].Nombre + "!!!!!");
                    Console.WriteLine("Eres el ganador!!!!");
                    HelperImagenes.GanadorDelJuego();
                }
                else
                {
                    Console.WriteLine("Ganador: " + listapersonajes[0].Nombre);
                    Console.WriteLine("Perdiste!!!");
                    HelperImagenes.Perdedor();
                    Console.WriteLine("Intenta de nuevo mas tarde");
                }

            }
        }
        else
        {
            Console.WriteLine("Error, No se ingreso un numero");
        }
    }

    public static void MostrarPersonajes(List<Personaje> lista)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            Console.WriteLine(i + "-" + lista[i].Nombre);
        }
    }

    public static void Pelea(Personaje ataca, Personaje defiende)
    {
        int ataque = 0;
        int defensa = 0;
        int efectividad = 0;
        int constanteDeAjuste = 500;
        int danioprovocado = 0;
        FabricaDePersonajes fp2 = new FabricaDePersonajes();

        ataque = ataca.Destreza * ataca.Fuerza * ataca.Nivel;
        efectividad = fp2.NumeroRandom(1, 101);

        defensa = defiende.Armadura * defiende.Velocidad;
        danioprovocado = (ataque * efectividad - defensa) / constanteDeAjuste;
        defiende.Salud -= danioprovocado;

    }
}

//controlar juego
//agregar algo para que no pase todo muy rapido