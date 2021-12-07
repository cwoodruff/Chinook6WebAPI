using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.DataCmpldQry.Repositories;

public class CustomerRepository : CpmldQryRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(ChinookContext context) : base(context)
    {
    }

    public async Task<List<Customer>> GetAll() => await _context.GetAllCustomers().ToListAsync();

    public async Task<Customer?> GetById(int id) => await _context.GetCustomer(id);

    public async Task<List<Customer>> GetBySupportRepId(int id) => await _context.GetCustomerBySupportRepId(id).ToListAsync();
}