namespace AquaAirAlert.Infrastructure.Data;

public class alert
{
    public long Id { get; set; } 
    public string Localizacao { get; set; } = string.Empty;
    public DateTime Data { get; set; } = DateTime.Now;
    public string Descricao { get; set; } = string.Empty;
}