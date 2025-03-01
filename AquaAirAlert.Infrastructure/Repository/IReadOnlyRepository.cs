using AquaAirAlert.Infrastructure.Data;

namespace AquaAirAlert.Infrastructure.Repository;

public interface  IReadOnlyRepository
{
    public Task<List<alert>> GetAll();

}