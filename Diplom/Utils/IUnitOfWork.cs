using Diplom.Models;
using Diplom.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Utils
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Department> Departments { get; }
        GenericRepository<Discipline> Disciplines { get; }
        GenericRepository<User> Users { get; }
        void Save();
    }
}
