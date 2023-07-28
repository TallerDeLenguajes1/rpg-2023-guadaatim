using System;
using System.Text.Json;
using System.Collections.Generic;
using Personajes;
namespace TrabajandoJson;

public class PersonajesJson
{
    public void GuardarPersonaje(List<Personaje> listapersonajes, string archivo)
    {   
        string personajesjson = JsonSerializer.Serialize(listapersonajes);
        File.WriteAllText(archivo, personajesjson);
    }

    public List<Personaje> LeerPersonajes(string archivo)
    {
        string? jsonstring = File.ReadAllText(archivo);
        List<Personaje>? personajesdesserializados = JsonSerializer.Deserialize<List<Personaje>>(jsonstring);
        return personajesdesserializados;
    }

    public bool Existe(string archivo)
    {
        return File.Exists(archivo);
    }
}