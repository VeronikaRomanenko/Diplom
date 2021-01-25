using Diplom.Models;
using Diplom.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Controllers
{
    public class StatusController : Controller
    {
        private IUnitOfWork db;

        public StatusController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Statuses.Get());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Status status)
        {
            db.Statuses.Create(status);
            db.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(db.Statuses.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Status status)
        {
            db.Statuses.Update(status);
            db.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            db.Statuses.Remove(db.Statuses.FindById(id));
            db.Save();
            return RedirectToAction("Index");
        }
    }
}
