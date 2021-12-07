using Chinook.Domain.Entities;

namespace Chinook.DataCmpldQry.Repositories;

public interface ICpmldQryRepository<T> where T : BaseEntity
{
    Task<bool> EntityExists(int id);
    Task<T> Add(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(int id);
}