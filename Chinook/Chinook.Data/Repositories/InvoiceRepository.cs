using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Data.Repositories;

public class InvoiceRepository : BaseRepository<Invoice>, IDisposable, IInvoiceRepository
{
    public InvoiceRepository(ChinookContext context) : base(context)
    {
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<Invoice>> GetByEmployeeId(int id) =>
        await _context.Customers.Where(a => a.SupportRepId == 5).SelectMany(t => t.Invoices)
            .AsNoTrackingWithIdentityResolution().ToListAsync();

    public async Task<List<Invoice>> GetByCustomerId(int id) =>
        await _context.Invoices.Where(i => i.CustomerId == id).AsNoTrackingWithIdentityResolution().ToListAsync();
}