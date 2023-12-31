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
    private DateOnly fechadenacimiento;
    private int edad;
    
    //caracteristicas
    private int velocidad;
    private int destreza;
    private int fuerza;
    private int nivel;
    private int armadura;
    private double salud;

    public string? Tipo { get => tipo; set => tipo = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Apodo { get => apodo; set => apodo = value; }
    public DateOnly Fechadenacimiento { get => fechadenacimiento; set => fechadenacimiento = value; }
    public int Edad { get => edad; set => edad = value; }
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public double Salud { get => salud; set => salud = value; }
}

public class FabricaDePersonajes
{
    public  Personaje crearPersonaje()
    {
        ServicioApi HelperApi = new ServicioApi();

        int id = NumeroRandom(1, 19);
        var p = new Personaje();

        HelperApi.ConsultaApi(id);
        
        p.Nombre = HelperApi.Nombre;
        p.Tipo = HelperApi.Especie;

        int dia = 0;
        int mes = NumeroRandom(1, 12);
        
        if (mes == 2)
        {
            dia = NumeroRandom(1, 28);
        } else
        {
            if (mes == 4 || mes == 6 || mes == 9 || mes == 11)
            {
                dia = NumeroRandom(1, 30); 
            } else
            {
                dia = NumeroRandom(1, 31);
            }
        }
        int anio = NumeroRandom(1723, 2023);

        //controlar dias de meses
        p.Fechadenacimiento = new DateOnly(anio, mes, dia);
        p.Edad = DateTime.Now.Year - p.Fechadenacimiento.Year;
        p.Apodo = p.Nombre;
        
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