using System.Text.Json.Serialization;

namespace AquaAirAlert.Communication.Response;

public class ResponseAirPolluition
{
    
        [JsonPropertyName("list")]
        public List<ListItem> List { get; set; }

        public class ListItem
        {
                [JsonPropertyName("main")]
                public Mainn Main { get; set; }
        }

        public class Mainn
        {
                [JsonPropertyName("aqi")]
                public float Aqi { get; set; }
        }
    
}