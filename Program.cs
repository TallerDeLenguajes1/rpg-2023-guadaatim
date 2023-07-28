using Personajes;
using TrabajandoJson;
using RickandMorty;
using Api;
using ImagenesyMensajes;
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
            listapersonajes = CrearLista(listapersonajes);  
            HelperJson.GuardarPersonaje(listapersonajes, nombreArchivo);
        }
        else
        {
            listapersonajes = HelperJson.LeerPersonajes(nombreArchivo);
        } 

        //juego
        Figuras HelperImagenes = new Figuras();

        HelperImagenes.Titulo();
        Console.ReadLine();
        HelperImagenes.Bienvenido();
        HelperImagenes.MensajeInicio();
        Console.WriteLine("Presiona ENTER para comenzar el juego");
        Console.ReadLine();
        
        int elegido;
        bool control;

        do
        {
            HelperImagenes.MensajeMostrarPersonajes();
            MostrarPersonajes(listapersonajes);

            Console.WriteLine("Elija un personaje: ");
            control = int.TryParse(Console.ReadLine(), out elegido);

            if (control && elegido < listapersonajes.Count)
            {
                var personajeElegido = listapersonajes[elegido];
                var enemigo = new Personaje();
                listapersonajes.Remove(personajeElegido);

                do
                {
                    HelperImagenes.CuadroArriba();
                    Console.WriteLine("     Su personaje: " + personajeElegido.Nombre);
                    HelperImagenes.CuadroAbajo();


                    enemigo = listapersonajes[fp.NumeroRandom(0, listapersonajes.Count - 1)];
                    HelperImagenes.CuadroArriba();
                    Console.WriteLine("     Te enfrentas a: " + enemigo.Nombre);
                    HelperImagenes.CuadroAbajo();
                    Console.ReadLine();

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
                        HelperImagenes.Perdedor();
                        HelperImagenes.MensajePerdedor();
                        Console.ReadLine();

                        Console.WriteLine("CAMBIA DE PERSONAJE");
                        Console.ReadLine();
                        enemigo.Salud += 50;

                        do
                        {                    
                            Console.WriteLine("ELIGE: ");
                            HelperImagenes.MensajeMostrarPersonajes();
                            MostrarPersonajes(listapersonajes);

                            control = int.TryParse(Console.ReadLine(), out elegido);

                            if (control && elegido < listapersonajes.Count)
                            {
                                personajeElegido = listapersonajes[elegido];
                                listapersonajes.Remove(personajeElegido);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("ERROR. No se ingreso un numero o esta fuera de rango");
                                Console.WriteLine("Intente de nuevo");
                                Console.ReadLine();
                            }
                        
                        } while (control != true || elegido >= listapersonajes.Count);
                    }
                    else
                    {
                        personajeElegido.Salud += 50;
                        HelperImagenes.Ganador();
                        HelperImagenes.MensajeGanador();
                        Console.WriteLine("Sigue asi!!!");
                        listapersonajes.Remove(enemigo);
                        Console.WriteLine("Presiona ENTER para seguir jugando");
                        Console.ReadLine();
                    }

                } while (listapersonajes.Count > 1);

                HelperImagenes.BatallaFinal();
                HelperImagenes.CuadroArriba();
                Console.WriteLine("     Su personaje: " + personajeElegido.Nombre);
                HelperImagenes.CuadroAbajo();
                
                enemigo = listapersonajes[0];
                HelperImagenes.CuadroArriba();
                Console.WriteLine("     Te enfrentas a: " + enemigo.Nombre);
                HelperImagenes.CuadroAbajo();

                Console.ReadLine();

                do
                {
                    int turno2 = fp.NumeroRandom(1, 2);

                    if (turno2 == 1)
                    {
                        Pelea(personajeElegido, enemigo);
                    }
                    else
                    {
                        Pelea(enemigo, personajeElegido);
                    }

                } while (personajeElegido.Salud >= 0 && enemigo.Salud >= 0);


                if (personajeElegido.Salud >= 0)
                {
                    HelperImagenes.GanadorDelJuegoMensaje();
                    HelperImagenes.GanadorDelJuego(personajeElegido);
                } 
                else
                {
                    HelperImagenes.PerdedorDelJuego();
                    Console.ReadLine();
                    HelperImagenes.GanadorDelJuego(listapersonajes[0]);
                    Console.WriteLine("Intenta de nuevo mas tarde");
                }
                break;
            }
            else
            {
                Console.WriteLine("Error. No se ingreso un numero o esta fuera de rango");
                Console.WriteLine("Intente de nuevo");
                Console.ReadLine();
            }

        } while (control != true || elegido >= listapersonajes.Count);

        File.Delete(nombreArchivo);
    }

    public static void MostrarPersonajes(List<Personaje> lista)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            Console.WriteLine("══════════════════════════════════════════════");
            Console.WriteLine(     i + "-" + lista[i].Nombre);
            Console.WriteLine("");
            Console.WriteLine("     Tipo: " + lista[i].Tipo);
            Console.WriteLine("     Nivel: " + lista[i].Nivel);
            Console.WriteLine("     Fuerza: " + lista[i].Fuerza);
            Console.WriteLine("     Velocidad: " + lista[i].Velocidad);
            Console.WriteLine("     Armadura: " + lista[i].Armadura);
            Console.WriteLine("══════════════════════════════════════════════");
        }
    }

    public static void Pelea(Personaje ataca, Personaje defiende)
    {
        int ataque = 0;
        int defensa = 0;
        int efectividad = 0;
        int constanteDeAjuste = 500;
        double danioprovocado = 0;
        FabricaDePersonajes fp2 = new FabricaDePersonajes();

        ataque = ataca.Destreza * ataca.Fuerza * ataca.Nivel;
        efectividad = fp2.NumeroRandom(1, 100);

        defensa = defiende.Armadura * defiende.Velocidad;
        danioprovocado = (ataque * efectividad - defensa) / constanteDeAjuste;
        danioprovocado = ((int)Math.Round(danioprovocado, MidpointRounding.AwayFromZero));
        defiende.Salud -= danioprovocado;
    }
    
    public static List<Personaje> CrearLista(List<Personaje> lista)
    {
        List<Personaje> listitapersonajes = new List<Personaje>();
        FabricaDePersonajes fp3 = new FabricaDePersonajes();
        int j = 0;

        for (int i = 0; i < 10; i++)
        {
            var personaje = fp3.crearPersonaje();

            foreach (var repetido in listitapersonajes)
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
                listitapersonajes.Add(personaje);
            }    
        }

        return listitapersonajes;
    }
}