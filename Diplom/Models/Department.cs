using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
        public Department()
        {
            Positions = new List<Position>();
        }
    }
}
