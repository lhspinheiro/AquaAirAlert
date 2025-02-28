namespace AquaAirAlert.Communication.Request;

public class AlertRequest
{
    public string Localizacao { get; set; } = string.Empty;
    public DateTime Data { get; set; } = DateTime.Now;
    public string Descricao { get; set; } = string.Empty;
}