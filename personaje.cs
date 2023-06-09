namespace Personajes;

public class Personaje
{
    //datos
    private Tipos tipo;
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
    internal Tipos Tipo { get => tipo; set => tipo = value; }
}

public class FabricaDePersonajes
{
    private static Personaje crearPersonaje()
    {

        var personaje = new Personaje();

        
        
        


        return personaje;
    }

    private static int NumeroRandom(int inicio, int final)
    {
        Random random = new Random();

        int numerorandom;
        numerorandom = random.Next(inicio, final+1);

        return numerorandom;
    }

}

enum Tipos
{
    Dios,
    Semidios,
    Monstruo,
}

enum Nombre
{
    Zeus,
    Hera,
    Poseidon, 
    Hades,
    Atenea,
    Afrodita,
    Dioniosio, 
    Apolo, 
    Artemisa,
    Hermes,
    Hefesto,
    Demeter,
    Hestia,
}