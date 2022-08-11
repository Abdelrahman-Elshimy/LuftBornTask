using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Luftborn.core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        T Find(Expression<Func<T,bool>> criteria, string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T,bool>> criteria, string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int take, int skip);
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        T Update(T entity);
        void Delete(T entity);
        void Attach(T entity);
        int Count();

    }
}
