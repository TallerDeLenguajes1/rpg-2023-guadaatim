using System.Text.Json;
using System.IO;
using System.Collections.Generic;
namespace Personajes;

public class Personaje
{
    //datos
    private string? tipo;
    private string? nombre;
    private string? apodo;
    private DateTime fechadenacimiento;
    private int edad;
    
    //caracteristicas
    private int velocidad;
    private int destreza;
    private int fuerza;
    private int nivel;
    private int armadura;
    private int salud;

    public string? Tipo { get => tipo; set => tipo = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Apodo { get => apodo; set => apodo = value; }
    public DateTime Fechadenacimiento { get => fechadenacimiento; set => fechadenacimiento = value; }
    public int Edad { get => edad; set => edad = value; }
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = value; }
}

public class FabricaDePersonajes
{
    public  Personaje crearPersonaje()
    {
        string[] nombres = {"Zeus", "Poseidon", "Hades", "Hera", "Demeter", "Afrodita", "Ares", "Atenea", "Apolo", "Artemisa", "Hefesto", "Dionisio"};
        string[] tipos = {"Dios", "Semidios"};

        var p = new Personaje();

        int nombre = NumeroRandom(0, 11);
        p.Nombre = nombres[nombre];

        int tipo = NumeroRandom(0, 1);
        p.Tipo = tipos[tipo];

        int dia = NumeroRandom(1, 31);
        int mes = NumeroRandom(1, 12);
        int anio = NumeroRandom(1723, 2023);

        //controlar dias de meses
        p.Fechadenacimiento = new DateTime(anio, mes, dia);
        p.Edad = DateTime.Now.Year - p.Fechadenacimiento.Year;
        p.Velocidad = NumeroRandom(1, 10);
        p.Destreza = NumeroRandom(1, 5);
        p.Fuerza = NumeroRandom(1, 10);
        p.Nivel = NumeroRandom(1, 10);
        p.Armadura = NumeroRandom(1, 10);
        p.Salud = 100;

        return p;
    }

    public static int NumeroRandom(int inicio, int final)
    {
        Random random = new Random();

        int numerorandom;
        numerorandom = random.Next(inicio, final+1);

        return numerorandom;
    }
}

public class PersonajesJson
{
    public void GuardarPersonaje(List<Personaje> listapersonajes, string archivo)
    {   
        string personajesjson = JsonSerializer.Serialize(listapersonajes);
        File.WriteAllText(archivo, personajesjson);
    }

    public List<Personaje> LeerPersonajes(string archivo)
    {
        string jsonstring = File.ReadAllText(archivo);
        List<Personaje> personajesdesserializados = JsonSerializer.Deserialize<List<Personaje>>(jsonstring);
        return personajesdesserializados;
    }

    public bool Existe(string archivo)
    {
        return File.Exists(archivo);
    }
}