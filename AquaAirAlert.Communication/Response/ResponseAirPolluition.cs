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

                [JsonPropertyName("description")] 
                public string Description { get; set; } = string.Empty; 


        }
        
        public void SetDescriptionForAqi()
        {
                foreach (var listItem in List)
                {
                        var aqi = listItem.Main.Aqi;

                        string description = "";

                        switch (aqi)
                        {
                                case 1:
                                        description = "Good";
                                        break; 
                                case 2:
                                        description = "Fair";
                                        break;
                                case 3:
                                        description = "Moderate";
                                        break;
                                case 4:
                                        description = "Poor";
                                        break;
                                case 5:
                                        description = "Very Poor";
                                        break;
                                default:
                                        description = "Unknown";
                                        break;
                        }
                        listItem.Main.Description = description;
                }
        }
}