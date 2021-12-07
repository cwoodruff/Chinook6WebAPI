using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chinook.Domain.Entities;

namespace Chinook.Domain.Repositories;

public interface ICustomerRepository : IRepository<Customer>, IDisposable
{
    Task<List<Customer>> GetBySupportRepId(int id);
}