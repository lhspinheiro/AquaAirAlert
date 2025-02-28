namespace AquaAirAlert.Infrastructure.Data;

public class alert
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Localizacao { get; set; } = string.Empty;
    public DateTime Data { get; set; } = DateTime.Now;
    public string Descricao { get; set; } = string.Empty;
}