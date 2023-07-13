using System;
using System.IO;
using System.Collections.Generic;
using System.Net;
using RickandMorty;
using System.Text.Json;
namespace Api;

public class ap{

    private int id;
    private string nombre;
    private string especie;
    private string estado;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Especie { get => especie; set => especie = value; }
    public string Estado { get => estado; set => estado = value; }

    public void ConsultaApi(int id)
    {
        var url = "https://rickandmortyapi.com/api/character";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "application/json";

        try
        {
            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return;

                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        RickAndMortyApi personaje = JsonSerializer.Deserialize<RickAndMortyApi>(responseBody);

                        Nombre = personaje.results[id].name;
                        Especie = personaje.results[id].species;
                        Estado = personaje.results[id].status;                        
                    }
                }
            }
        }
        catch (WebException ex)
        {
            Console.WriteLine("Problemas de acceso a la API");
            throw;
        }
    }
}