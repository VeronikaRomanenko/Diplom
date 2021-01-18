using Diplom.Models;
using Diplom.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Controllers
{
    public class DisciplineController : Controller
    {
        private IUnitOfWork db;

        public DisciplineController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Disciplines.Get());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Discipline discipline)
        {
            db.Disciplines.Create(discipline);
            db.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(db.Disciplines.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Discipline discipline)
        {
            db.Disciplines.Update(discipline);
            db.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            db.Disciplines.Remove(db.Disciplines.FindById(id));
            db.Save();
            return RedirectToAction("Index");
        }
    }
}
