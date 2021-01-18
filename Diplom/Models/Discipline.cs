using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Models
{
    public class Discipline
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Technology> Technologies { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
        public Discipline()
        {
            Technologies = new List<Technology>();
            Vacancies = new List<Vacancy>();
        }
    }
}
