namespace AquaAirAlert.Communication.Response;

public class ResponseAlert 
{
    
    public long Id { get; set; } 
    public string Localizacao { get; set; } = string.Empty;
    public DateTime Data { get; set; } = DateTime.Now;
    public string Descricao { get; set; } = string.Empty;
    
    public long UserId { get; set; }  
}