﻿using Diplom.Models;
using Diplom.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Utils
{
    public class UnitOfWork : IUnitOfWork
    {
        private MyDbContext context;
        private GenericRepository<Department> departments;
        private GenericRepository<Discipline> disciplines;
        private GenericRepository<Technology> technologies;
        private GenericRepository<Position> positions;
        private GenericRepository<User> users;

        public UnitOfWork(MyDbContext context)
        {
            this.context = context;
        }

        public GenericRepository<Department> Departments
        {
            get
            {
                if (departments == null)
                    departments = new GenericRepository<Department>(context);
                return departments;
            }
        }
        public GenericRepository<Discipline> Disciplines
        {
            get
            {
                if (disciplines == null)
                    disciplines = new GenericRepository<Discipline>(context);
                return disciplines;
            }
        }
        public GenericRepository<Technology> Technologies
        {
            get
            {
                if (technologies == null)
                    technologies = new GenericRepository<Technology>(context);
                return technologies;
            }
        }
        public GenericRepository<Position> Positions
        {
            get
            {
                if (positions == null)
                    positions = new GenericRepository<Position>(context);
                return positions;
            }
        }
        public GenericRepository<User> Users
        {
            get
            {
                if (users == null)
                    users = new GenericRepository<User>(context);
                return users;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
