using System;
using System.Text.Json;
using System.IO;
using System.Net;
using System.Collections.Generic;
using Api;
using RickandMorty;
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
        ap HelperApi = new ap();

        int id = NumeroRandom(1, 20);
        var p = new Personaje();

        HelperApi.ConsultaApi(id);
        
        p.Nombre = HelperApi.Nombre;
        p.Tipo = HelperApi.Especie;

        int dia = NumeroRandom(1, 31);
        int mes = NumeroRandom(1, 12);
        int anio = NumeroRandom(1723, 2023);

        //controlar dias de meses
        p.Fechadenacimiento = new DateTime(anio, mes, dia).Date;
        p.Edad = DateTime.Now.Year - p.Fechadenacimiento.Year;
        p.Velocidad = NumeroRandom(1, 10);
        p.Destreza = NumeroRandom(1, 5);
        p.Fuerza = NumeroRandom(1, 10);
        p.Nivel = NumeroRandom(1, 10);
        p.Armadura = NumeroRandom(1, 10);
        p.Salud = 100;

        return p;
    }

    public int NumeroRandom(int inicio, int final)
    {
        Random random = new Random();

        int numerorandom;
        numerorandom = random.Next(inicio, final+1);

        return numerorandom;
    }
}