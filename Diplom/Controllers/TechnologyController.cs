using Diplom.Models;
using Diplom.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Controllers
{
    [Authorize]
    public class TechnologyController : Controller
    {
        private IUnitOfWork db;

        public TechnologyController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Technologies.Get());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Technology technology)
        {
            db.Technologies.Create(technology);
            db.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(db.Technologies.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Technology technology)
        {
            db.Technologies.Update(technology);
            db.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            db.Technologies.Remove(db.Technologies.FindById(id));
            db.Save();
            return RedirectToAction("Index");
        }
    }
}
