using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int IdDepartment { get; set; }

        [ForeignKey(nameof(IdDepartment))]
        public virtual Department Department { get; set; }
        public virtual ICollection<PeoplePosition> PeoplePositions { get; set; }
        public Position()
        {
            PeoplePositions = new List<PeoplePosition>();
        }
    }
}
