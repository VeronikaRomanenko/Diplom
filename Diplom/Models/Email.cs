﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Models
{
    public class Email
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public int IdPerson { get; set; }

        [ForeignKey(nameof(IdPerson))]
        public virtual Person Person { get; set; }
    }
}
