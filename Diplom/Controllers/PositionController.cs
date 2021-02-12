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
    public class PositionController : Controller
    {
        private IUnitOfWork db;

        public PositionController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Positions.Get());
        }

        [HttpGet]
        public IActionResult Create()
        {
            SelectList departments = new SelectList(db.Departments.Get(), "Id", "Title");
            ViewBag.Departments = departments;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Position position)
        {
            db.Positions.Create(position);
            db.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            SelectList departments = new SelectList(db.Departments.Get(), "Id", "Title");
            ViewBag.Departments = departments;
            return View(db.Positions.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Position position)
        {
            db.Positions.Update(position);
            db.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            db.Positions.Remove(db.Positions.FindById(id));
            db.Save();
            return RedirectToAction("Index");
        }
    }
}
