using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Data.Repositories;

public class CustomerRepository : BaseRepository<Customer>, IDisposable, ICustomerRepository
{
    public CustomerRepository(ChinookContext context) : base(context)
    {
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<Customer>> GetBySupportRepId(int id) =>
        await _context.Customers.Where(a => a.SupportRepId == id).AsNoTrackingWithIdentityResolution()
            .ToListAsync();
}