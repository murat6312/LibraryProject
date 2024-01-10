
namespace DataAcces.Repositorys
{
    public interface IRepository<T>
    {
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
        IQueryable<T> GetQueryable();
    }
}
