using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.DataCmpldQry.Repositories;

public class EmployeeRepository : CpmldQryRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ChinookContext context) : base(context)
    {
    }

    async Task<List<Employee>> IRepository<Employee>.GetAll() => await _context.GetAllEmployees().ToListAsync();

    async Task<Employee?> IRepository<Employee>.GetById(int id) => await _context.GetEmployee(id);

    public async Task<Employee> GetReportsTo(int id) => await _context.GetEmployeeGetReportsTo(id);

    public async Task<List<Employee>> GetDirectReports(int id) => await _context.GetEmployeeDirectReports(id).ToListAsync();
}