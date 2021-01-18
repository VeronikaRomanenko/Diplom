using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<PeoplePosition> PeoplePositions { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<SocialMediaLink> SocialMediaLinks { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
    }
}
