using System.Text.Json.Serialization;
namespace RickandMorty;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Info
    {
        [JsonPropertyName("count")]
        public int count { get; set; }

        [JsonPropertyName("pages")]
        public int pages { get; set; }

        [JsonPropertyName("next")]
        public string next { get; set; }

        [JsonPropertyName("prev")]
        public object prev { get; set; }
    }

    public class Location
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }
    }

    public class Origin
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("status")]
        public string status { get; set; }

        [JsonPropertyName("species")]
        public string species { get; set; }

        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonPropertyName("gender")]
        public string gender { get; set; }

        [JsonPropertyName("origin")]
        public Origin origin { get; set; }

        [JsonPropertyName("location")]
        public Location location { get; set; }

        [JsonPropertyName("image")]
        public string image { get; set; }

        [JsonPropertyName("episode")]
        public List<string> episode { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }

        [JsonPropertyName("created")]
        public DateTime created { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("info")]
        public Info info { get; set; }

        [JsonPropertyName("results")]
        public List<Result> results { get; set; }
    }