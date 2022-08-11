using Luftborn.core;
using Luftborn.core.Interfaces;
using Luftborn.core.Models;
using LuftbornTask.EF.Repositories;
using LuftBornTask.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTask.EF
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _context;
        public UnitofWork(ApplicationDbContext context)
        {
            _context = context;
            Authors = new BaseRepository<Author>(_context);
            Books = new BaseRepository<Book>(_context);
        }
        public IBaseRepository<Author> Authors { get; private set; }

        public IBaseRepository<Book> Books { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
