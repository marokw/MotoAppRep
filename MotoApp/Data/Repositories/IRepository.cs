using MotoApp.Data.Entities;

namespace MotoApp.Data.Repositories;

public interface IReadRepository<out T> where T : class, IEntity
{
    IEnumerable<T> GetAll();
    T? GetById(int id);
}

public interface IWriteRepository<in T> where T : class, IEntity
{
    void Add(T item);
    void Remove(T item);
    void Save();
}

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
{


}

