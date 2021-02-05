using Diplom.Models;
using Diplom.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Controllers
{
    public class UserController : Controller
    {
        private IUnitOfWork db;

        public UserController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Users.Get());
        }

        public IActionResult Details(int id)
        {
            return View(db.Users.FindById(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            SelectList roles = new SelectList(db.Roles.Get(), "Id", "Title");
            ViewBag.Roles = roles;
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            db.Users.Create(user);
            db.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            SelectList roles = new SelectList(db.Roles.Get(), "Id", "Title");
            ViewBag.Roles = roles;
            return View(db.Users.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            db.Users.Update(user);
            db.Save();
            return RedirectToAction("Details", new { id = user.Id });
        }

        public IActionResult Remove(int id)
        {
            db.Users.Remove(db.Users.FindById(id));
            db.Save();
            return RedirectToAction("Index");
        }
    }
}
