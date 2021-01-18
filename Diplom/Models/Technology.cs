using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Models
{
    public class Technology
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Discipline> Disciplines { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public Technology()
        {
            Disciplines = new List<Discipline>();
            People = new List<Person>();
        }
    }
}
