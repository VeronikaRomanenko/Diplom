using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Models
{
    public static class DbInitializer
    {
        public static void Initialize(MyDbContext context)
        {
            if (!context.Sexes.Any())
            {
                context.Sexes.AddRange(
                    new Sex { Title = "мужской" },
                    new Sex { Title = "женский" });
                context.SaveChanges();
            }
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Role { Title = "admin" });
                context.SaveChanges();
            }
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User { Login = "admin", Password = "admin", Email = "admin", IdRole = 1 });
                context.SaveChanges();
            }
        }
    }
}
