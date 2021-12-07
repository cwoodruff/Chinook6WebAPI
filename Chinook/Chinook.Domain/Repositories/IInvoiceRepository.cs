using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chinook.Domain.Entities;

namespace Chinook.Domain.Repositories;

public interface IInvoiceRepository : IRepository<Invoice>, IDisposable
{
    Task<List<Invoice>> GetByCustomerId(int id);
    Task<List<Invoice>> GetByEmployeeId(int id);
}