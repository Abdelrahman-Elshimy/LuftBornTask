using Luftborn.core.Interfaces;
using LuftBornTask.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTask.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }
        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            return entities;
        }
        public void Attach(T entity) => _context.Set<T>().Attach(entity);
        public int Count() => _context.Set<T>().Count();
        public void Delete(T entity) => _context.Set<T>().Remove(entity);
        public T Find(Expression<Func<T, bool>> criteria, string[] includes = null) {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);
            return query.SingleOrDefault(criteria);
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);
            return query.Where(criteria).ToList();
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int take, int skip) => _context.Set<T>().Where(criteria).Skip(skip).Take(take).ToList();
        public IEnumerable<T> GetAll() => _context.Set<T>().ToList();
        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);
        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }
    }
}
