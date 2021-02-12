using Diplom.Models;
using Diplom.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        private IUnitOfWork db;

        public PersonController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.People.Get());
        }

        public IActionResult Details(int id)
        {
            return View(db.People.FindById(id));
        }

        public IActionResult AddComment(int id, string text)
        {
            int userId = db.Users.Get(i => i.Login == User.Identity.Name).FirstOrDefault().Id;
            db.Comments.Create(new Comment() { DateTime = DateTime.Now, IdPerson = id, CommentText = text, IdUser = userId, IsLog = false });
            return RedirectToAction("Details", new { id = id });
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Statuses = new SelectList(db.Statuses.Get(), "Id", "Title");
            ViewBag.Technologies = (List<Technology>)db.Technologies.Get();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person, string[] phones, string[] emails, string[] socialMediaLinks, int[] selectedTechnologies)
        {
            if (phones != null)
            {
                foreach (var item in phones)
                {
                    person.Phones.Add(new Phone() { Number = item });
                }
            }
            if (emails != null)
            {
                foreach (var item in emails)
                {
                    person.Emails.Add(new Email() { EmailAddress = item });
                }
            }
            if (socialMediaLinks != null)
            {
                foreach (var item in socialMediaLinks)
                {
                    person.SocialMediaLinks.Add(new SocialMediaLink() { Link = item });
                }
            }
            if (selectedTechnologies != null)
            {
                foreach (var item in db.Technologies.Get().Where(t => selectedTechnologies.Contains(t.Id)))
                {
                    person.Technologies.Add(item);
                }
            }
            db.People.Create(person);
            db.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Statuses = new SelectList(db.Statuses.Get(), "Id", "Title");
            ViewBag.Technologies = (List<Technology>)db.Technologies.Get();
            return View(db.People.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Person person, string[] phones, string[] emails, string[] socialMediaLinks, int[] selectedTechnologies)
        {
            Person newPerson = db.People.FindById(person.Id);
            newPerson.Name = person.Name;
            newPerson.Surname = person.Surname;
            newPerson.Patronymic = person.Patronymic;
            newPerson.DateOfBirth = person.DateOfBirth;
            newPerson.Education = person.Education;
            newPerson.Expirience = person.Expirience;
            newPerson.PhotoPath = person.PhotoPath;
            newPerson.IdSex = person.IdSex;
            newPerson.IdStatus = person.IdStatus;

            newPerson.Phones.Clear();
            if (phones != null)
            {
                foreach (var item in phones)
                {
                    newPerson.Phones.Add(new Phone() { Number = item });
                }
            }
            newPerson.Emails.Clear();
            if (emails != null)
            {
                foreach (var item in emails)
                {
                    newPerson.Emails.Add(new Email() { EmailAddress = item });
                }
            }
            newPerson.SocialMediaLinks.Clear();
            if (socialMediaLinks != null)
            {
                foreach (var item in socialMediaLinks)
                {
                    newPerson.SocialMediaLinks.Add(new SocialMediaLink() { Link = item });
                }
            }
            newPerson.Technologies.Clear();
            if (selectedTechnologies != null)
            {
                foreach (var item in db.Technologies.Get().Where(t => selectedTechnologies.Contains(t.Id)))
                {
                    newPerson.Technologies.Add(item);
                }
            }
            db.People.Update(newPerson);
            db.Save();
            return RedirectToAction("Details", new { id = person.Id });
        }

        public IActionResult Remove(int id)
        {
            db.People.Remove(db.People.FindById(id));
            db.Save();
            return RedirectToAction("Index");
        }
    }
}
