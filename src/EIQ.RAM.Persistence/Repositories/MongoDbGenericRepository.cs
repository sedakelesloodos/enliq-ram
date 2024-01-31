using EIQ.RAM.Application.Interfaces.Repositories;
using EIQ.RAM.Domain.Entities;
using EIQ.RAM.Domain.Interfaces;
using Microsoft.VisualBasic;
using MongoDB.Driver;

namespace EIQ.RAM.Persistence.Repositories;

public abstract class MongoDbGenericRepository<T> : IMongoDbGenericRepository<T> where T : MongoDbBaseEntity
{
    protected readonly IMongoCollection<T> Collection;

    protected MongoDbGenericRepository(IMongoDatabase database)
    {
        Collection = database.GetCollection<T>($"{typeof(T).Name.ToLower()}s");
    }

    protected MongoDbGenericRepository(IMongoDatabase database, string collectionName)
    {
        Collection = database.GetCollection<T>(collectionName);
    }

    public virtual async Task<T> GetAsync(string id, CancellationToken cancellationToken)
    {
        return await Collection.Find<T>(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public virtual async Task<T> InsertAsync(T entity, CancellationToken cancellationToken)
    {
        if (typeof(IHasCreation).IsAssignableFrom(typeof(T)) &&
            ((IHasCreation)entity).CreatedAt == DateTime.MinValue)
        {
            ((IHasCreation)entity).CreatedAt = DateTime.UtcNow;
        }

        await Collection.InsertOneAsync(entity, cancellationToken);
        return entity;
    }

    public virtual async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        if (typeof(IHasUpdate).IsAssignableFrom(typeof(T)))
        {
            ((IHasUpdate)entity).UpdatedAt = DateTime.UtcNow;
        }
        var options = new ReplaceOptions { IsUpsert = false };

        var updatedEntity = await Collection.ReplaceOneAsync(x => x.Id == entity.Id, entity, options: options);

        return entity;
    }
}
