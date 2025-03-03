using System.Text.Json.Serialization;

namespace AquaAirAlert.Communication.Response;

public class WeatherResponse
{
    
    [JsonPropertyName("coord")]
    public Coord? coord { get; set; }
    
    [JsonPropertyName("main")]
    public  Main? main { get; set; }
    
    [JsonPropertyName("weather")]
    public List<Weather> weather { get; set; }
    
    [JsonPropertyName("wind")]
    public Wind? wind { get; set; }
    
    [JsonPropertyName("sys")]
    public Sys? sys { get; set; }

    
    
    public class Coord
    {
        [JsonPropertyName("lon")]
        public float? lon { get; set; }
        
        [JsonPropertyName("lat")]
        public float? lat { get; set; }
    }
    
    
    
    public class Main 
    {
        [JsonPropertyName("temp")]
        public double? temp { get; set; }
        
        [JsonPropertyName("feels_like")]
        public double? feels_like { get; set; }
        
        [JsonPropertyName("temp_min")]
        public double? temp_min { get; set; }
        
        [JsonPropertyName("temp_max")]
        public double? temp_max { get; set; }
        
        [JsonPropertyName("pressure")]
        public int? pressure { get; set; }
    }
    
    public class Weather
    {
        [JsonPropertyName("main")]
        public string? main { get; set; }
        
        [JsonPropertyName("description")]
        public string? description { get; set; }
        
    }
    
    public class Wind
    {
        [JsonPropertyName("speed")]
        public double? speed { get; set; }
    }

    public class Sys
    {
        [JsonPropertyName("country")]
        public string? country { get; set; }
        
    }
    
    [JsonPropertyName("name")]
    public string? name { get; set; }
    
}