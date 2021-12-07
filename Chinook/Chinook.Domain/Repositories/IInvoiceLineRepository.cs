using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chinook.Domain.Entities;

namespace Chinook.Domain.Repositories;

public interface IInvoiceLineRepository : IRepository<InvoiceLine>, IDisposable
{
    Task<List<InvoiceLine>> GetByInvoiceId(int id);
    Task<List<InvoiceLine>> GetByTrackId(int id);
}