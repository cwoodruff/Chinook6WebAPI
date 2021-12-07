using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.DataCmpldQry.Repositories;

/// <summary>
/// The invoice repository.
/// </summary>
public class InvoiceRepository : CpmldQryRepository<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(ChinookContext context) : base(context)
    {
    }

    async Task<List<Invoice>> IRepository<Invoice>.GetAll() => await _context.GetAllInvoices().ToListAsync();

    async Task<Invoice?> IRepository<Invoice>.GetById(int id) => await _context.GetInvoice(id);

    public async Task<List<Invoice>> GetByEmployeeId(int id) => await _context.GetInvoicesByEmployeeId(id).ToListAsync();

    public async Task<List<Invoice>> GetByCustomerId(int id) => await _context.GetInvoicesByCustomerId(id).ToListAsync();
}