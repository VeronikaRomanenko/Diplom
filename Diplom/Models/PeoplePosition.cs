using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Models
{
    public class PeoplePosition
    {
        public int Id { get; set; }
        public double Salary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IdPerson { get; set; }
        public int IdPosition { get; set; }

        [ForeignKey(nameof(IdPerson))]
        public virtual Person Person { get; set; }
        [ForeignKey(nameof(IdPosition))]
        public virtual Position Position { get; set; }
    }
}
