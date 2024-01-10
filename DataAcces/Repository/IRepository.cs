using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Repository
{
    public interface IRepository<T>
    {
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
        IQueryable<T> GetQueryable();
    }
}
