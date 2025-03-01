

using AquaAirAlert.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Infrastructure.Repository;


internal class Repository : IReadOnlyRepository
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext  context)
    {
        _context = context;
    }
    
    public async Task<List<alert>> GetAll()
    {
        return await _context.Alerts.AsNoTracking().ToListAsync();
    }
}