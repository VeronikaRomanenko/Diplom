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
        GenericRepository<Technology> Technologies { get; }
        GenericRepository<Position> Positions { get; }
        GenericRepository<User> Users { get; }
        GenericRepository<Role> Roles { get; }
        GenericRepository<Status> Statuses { get; }
        GenericRepository<Person> People { get; }
        GenericRepository<Vacancy> Vacancies { get; }
        void Save();
    }
}
