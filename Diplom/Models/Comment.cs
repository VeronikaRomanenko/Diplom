using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsLog { get; set; }
        public int IdPerson { get; set; }
        public int IdUser { get; set; }

        [ForeignKey(nameof(IdPerson))]
        public virtual Person Person { get; set; }
        [ForeignKey(nameof(IdUser))]
        public virtual User User { get; set; }
    }
}
