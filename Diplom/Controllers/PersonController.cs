using Diplom.Models;
using Diplom.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Controllers
{
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            db.People.Create(person);
            db.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(db.People.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Person person)
        {
            db.People.Update(person);
            db.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            db.People.Remove(db.People.FindById(id));
            db.Save();
            return RedirectToAction("Index");
        }
    }
}
