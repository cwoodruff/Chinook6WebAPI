using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chinook.DataPostgres.Repositories;

public class CustomerRepository : BaseRepository<Customer>, IDisposable, ICustomerRepository
{
    public CustomerRepository(ChinookPostgresContext context) : base(context)
    {
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<Customer>> GetBySupportRepId(int id) =>
        await _context.Customers.Where(a => a.SupportRepId == id).AsNoTrackingWithIdentityResolution()
            .ToListAsync();
}