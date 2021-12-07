using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Data.Repositories;

public class InvoiceLineRepository : BaseRepository<InvoiceLine>, IDisposable, IInvoiceLineRepository
{
    public InvoiceLineRepository(ChinookContext context) : base(context)
    {
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<InvoiceLine>> GetByInvoiceId(int id) =>
        await _context.InvoiceLines.Where(a => a.InvoiceId == id).AsNoTrackingWithIdentityResolution()
            .ToListAsync();

    public async Task<List<InvoiceLine>> GetByTrackId(int id) =>
        await _context.InvoiceLines.Where(a => a.TrackId == id).AsNoTrackingWithIdentityResolution().ToListAsync();
}