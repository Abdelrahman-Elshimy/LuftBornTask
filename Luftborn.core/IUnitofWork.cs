using Luftborn.core.Interfaces;
using Luftborn.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luftborn.core
{
    public interface IUnitofWork: IDisposable
    {
        IBaseRepository<Author> Authors { get; }
        IBaseRepository<Book> Books { get; }

        int Complete();

    }
}
