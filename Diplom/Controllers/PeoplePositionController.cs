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
    public class PeoplePositionController : Controller
    {
        private IUnitOfWork db;

        public PeoplePositionController(IUnitOfWork db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.Person = db.People.FindById(id);
            ViewBag.Positions = new SelectList(db.Positions.Get(), "Id", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult Create(PeoplePosition pp)
        {
            pp.StartDate = DateTime.Now;
            pp.IsWorked = true;
            pp.Id = 0;
            db.PeoplePositions.Create(pp);
            db.Save();
            return RedirectToAction("Details", "Person", new { id = pp.IdPerson });
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(db.PeoplePositions.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(PeoplePosition pp)
        {
            PeoplePosition newPp = db.PeoplePositions.FindById(pp.Id);
            newPp.Salary = pp.Salary;
            newPp.StartDate = pp.StartDate;
            newPp.EndDate = pp.EndDate;
            db.PeoplePositions.Update(newPp);
            db.Save();
            return RedirectToAction("Details", "Person", new { id = pp.IdPerson });
        }

        public IActionResult Close(int id)
        {
            PeoplePosition pp = db.PeoplePositions.FindById(id);
            pp.IsWorked = false;
            pp.EndDate = DateTime.Now;
            db.Save();
            return RedirectToAction("Update", new { id = id });
        }
    }
}
