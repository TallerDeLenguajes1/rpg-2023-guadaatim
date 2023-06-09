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
    private static Personaje crearPersonaje()
    {
        string[] nombres = {"Zeus", "Poseidon", "Hades", "Hera", "Demeter", "Afrodita", "Ares", "Atenea", "Apolo", "Artemisa", "Hefesto", "Dionisio"};
        string[] tipos = {"Dios", "Semidios"};

        var personaje = new Personaje();

        int nombre = NumeroRandom(0, 11);
        personaje.Nombre = nombres[nombre];

        int tipo = NumeroRandom(0, 1);
        personaje.Tipo = tipos[tipo];

        int dia = NumeroRandom(0, 31);
        int mes = NumeroRandom(1, 12);
        int anio = NumeroRandom(1723, 2023);

        //controlar dias de meses
        personaje.Fechadenacimiento = new DateTime(anio, mes, dia);
        personaje.Edad = DateTime.Now.Year - personaje.Fechadenacimiento.Year;
        personaje.Velocidad = NumeroRandom(1, 10);
        personaje.Destreza = NumeroRandom(1, 5);
        personaje.Fuerza = NumeroRandom(1, 10);
        personaje.Nivel = NumeroRandom(1, 10);
        personaje.Armadura = NumeroRandom(1, 10);
        personaje.Salud = 100;

        return personaje;
    }

    private static int NumeroRandom(int inicio, int final)
    {
        Random random = new Random();

        int numerorandom;
        numerorandom = random.Next(inicio, final+1);

        return numerorandom;
    }

    private static void LeerPersonaje()
    {

    }

    private static void GuardarPersonaje()
    {

    }

}