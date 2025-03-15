namespace AquaAirAlert.Application.UseCase.Delete;

public interface IDeleteAlertUseCase
{
    public Task<bool> Delete(long id);
}