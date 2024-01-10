using DataAcces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly LibraryContext _libraryContext;

        public Repository(LibraryContext openLibraryContext)
        {
            _libraryContext = openLibraryContext;
        }

        public async Task Add(T entity)
        {
            _libraryContext.Set<T>().Add(entity);
            _libraryContext.SaveChanges();
        }

        public async Task Delete(T entity)
        {
            _libraryContext.Set<T>().Remove(entity);
            _libraryContext.SaveChanges();
        }

        public async Task Update(T entity)
        {
            _libraryContext.Set<T>().Update(entity);
            _libraryContext.SaveChanges();

        }

        public IQueryable<T> GetQueryable()
        {
            return _libraryContext.Set<T>().AsQueryable();
        }
    }
}
