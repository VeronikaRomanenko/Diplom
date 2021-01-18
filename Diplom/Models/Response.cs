using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Models
{
    public class Response
    {
        public int Id { get; set; }
        public DateTime ResponseDate { get; set; }
        public bool Status { get; set; }
        public int IdPerson { get; set; }
        public int IdVacancy { get; set; }

        [ForeignKey(nameof(IdPerson))]
        public virtual Person Person { get; set; }
        [ForeignKey(nameof(IdVacancy))]
        public virtual Vacancy Vacancy { get; set; }
    }
}
