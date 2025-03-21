namespace AquaAirAlert.Application.UseCase.Alerts.Delete;

public interface IDeleteAlertUseCase
{
    public Task<bool> Delete(long id);
}