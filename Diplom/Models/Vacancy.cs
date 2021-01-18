using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsArchived { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Response> Responses { get; set; }
        public virtual ICollection<Discipline> Disciplines { get; set; }
        public Vacancy()
        {
            Responses = new List<Response>();
            Disciplines = new List<Discipline>();
        }
    }
}
