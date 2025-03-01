using System.Text.Json.Serialization;

namespace AquaAirAlert.Communication.Response;

public class WeatherResponse
{
    
    [JsonPropertyName("weather")]
    public List<Weather> weather { get; set; }
    
    [JsonPropertyName("main")]
    public  Main? main { get; set; }
    
    
    
    
    public class Weather
    {
        [JsonPropertyName("main")]
        public string? main { get; set; }
        
        [JsonPropertyName("description")]
        public string? description { get; set; }
    }
    
    public class Main 
    {
        [JsonPropertyName("temp")]
        public double? temp { get; set; }
        
        [JsonPropertyName("temp_min")]
        public double? temp_min { get; set; }
        
        [JsonPropertyName("temp_max")]
        public double? temp_max { get; set; }
        
        [JsonPropertyName("pressure")]
        public int? pressure { get; set; }
    }
    
}