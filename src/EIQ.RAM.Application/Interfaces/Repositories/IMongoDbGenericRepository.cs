using System.Threading;
using System.Threading.Tasks;
using EIQ.RAM.Domain.Entities;

namespace EIQ.RAM.Application.Interfaces.Repositories;

public interface IMongoDbGenericRepository<T> where T : MongoDbBaseEntity
{
    Task<T> GetAsync(string id, CancellationToken cancellationToken);
    Task<T> InsertAsync(T entity, CancellationToken cancellationToken);
    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
}
