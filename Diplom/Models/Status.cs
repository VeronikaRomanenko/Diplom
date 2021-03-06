﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Person> People { get; set; }
        public Status()
        {
            People = new List<Person>();
        }
    }
}
