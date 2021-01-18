using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
