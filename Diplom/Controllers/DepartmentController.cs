using Diplom.Models;
using Diplom.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Controllers
{
    public class DepartmentController : Controller
    {
        private IUnitOfWork db;

        public DepartmentController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Departments.Get());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            db.Departments.Create(department);
            db.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(db.Departments.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Department department)
        {
            db.Departments.Update(department);
            db.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            db.Departments.Remove(db.Departments.FindById(id));
            db.Save();
            return RedirectToAction("Index");
        }
    }
}
