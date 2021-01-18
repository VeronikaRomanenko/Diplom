using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Models
{
    public class Sex
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Person> People { get; set; }
        public Sex()
        {
            People = new List<Person>();
        }
    }
}
