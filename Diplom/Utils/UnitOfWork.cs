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
        private GenericRepository<Role> roles;
        private GenericRepository<Status> statuses;
        private GenericRepository<Person> people;
        private GenericRepository<Comment> comments;
        private GenericRepository<Vacancy> vacancies;
        private GenericRepository<Response> responses;
        private GenericRepository<PeoplePosition> peoplePositions;

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
        public GenericRepository<Role> Roles
        {
            get
            {
                if (roles == null)
                    roles = new GenericRepository<Role>(context);
                return roles;
            }
        }
        public GenericRepository<Status> Statuses
        {
            get
            {
                if (statuses == null)
                    statuses = new GenericRepository<Status>(context);
                return statuses;
            }
        }
        public GenericRepository<Person> People
        {
            get
            {
                if (people == null)
                    people = new GenericRepository<Person>(context);
                return people;
            }
        }
        public GenericRepository<Comment> Comments
        {
            get
            {
                if (comments == null)
                    comments = new GenericRepository<Comment>(context);
                return comments;
            }
        }
        public GenericRepository<Vacancy> Vacancies
        {
            get
            {
                if (vacancies == null)
                    vacancies = new GenericRepository<Vacancy>(context);
                return vacancies;
            }
        }
        public GenericRepository<Response> Responses
        {
            get
            {
                if (responses == null)
                    responses = new GenericRepository<Response>(context);
                return responses;
            }
        }
        public GenericRepository<PeoplePosition> PeoplePositions
        {
            get
            {
                if (peoplePositions == null)
                    peoplePositions = new GenericRepository<PeoplePosition>(context);
                return peoplePositions;
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
