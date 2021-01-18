using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Education { get; set; }
        public string Expirience { get; set; }
        public string PhotoPath { get; set; }
        public int IdSex { get; set; }
        public int IdStatus { get; set; }

        [ForeignKey(nameof(IdSex))]
        public virtual Sex Sex { get; set; }
        [ForeignKey(nameof(IdStatus))]
        public virtual Status Status { get; set; }
        public virtual ICollection<SocialMediaLink> SocialMediaLinks { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PeoplePosition> PeoplePositions { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
        public virtual ICollection<Technology> Technologies { get; set; }
        public Person()
        {
            SocialMediaLinks = new List<SocialMediaLink>();
            Phones = new List<Phone>();
            Emails = new List<Email>();
            Comments = new List<Comment>();
            PeoplePositions = new List<PeoplePosition>();
            Responses = new List<Response>();
            Technologies = new List<Technology>();
        }
    }
}
