using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.DataCmpldQry.Repositories;

public class InvoiceLineRepository : CpmldQryRepository<InvoiceLine>, IInvoiceLineRepository
{
    public InvoiceLineRepository(ChinookContext context) : base(context)
    {
    }

    async Task<List<InvoiceLine>> IRepository<InvoiceLine>.GetAll() => await _context.GetAllInvoiceLines().ToListAsync();

    async Task<InvoiceLine?> IRepository<InvoiceLine>.GetById(int id) => await _context.GetInvoiceLine(id);

    public async Task<List<InvoiceLine>> GetByInvoiceId(int id) => await _context.GetInvoiceLinesByInvoiceId(id).ToListAsync();

    public async Task<List<InvoiceLine>> GetByTrackId(int id) => await _context.GetInvoiceLinesByTrackId(id).ToListAsync();
}