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
    public class ResponseController : Controller
    {
        private IUnitOfWork db;

        public ResponseController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Responses.Get().OrderByDescending(i => i.Status));
        }

        public IActionResult Details(int id)
        {
            Response r = db.Responses.FindById(id);
            String DisciplinesTechnologies = "";
            foreach (Discipline d in r.Vacancy.Disciplines)
            {
                DisciplinesTechnologies += (d.Title + "(");
                foreach (Technology t in d.Technologies)
                {
                    DisciplinesTechnologies += (t.Title + ", ");
                }
                DisciplinesTechnologies += ("); ");
            }
            bool isMeet = true;
            foreach (Discipline d in r.Vacancy.Disciplines)
            {
                foreach (Technology t in d.Technologies)
                {
                    if (!r.Person.Technologies.Contains(t))
                    {
                        isMeet = false;
                    }
                }
            }
            ViewBag.DisciplinesTechnologies = DisciplinesTechnologies;
            ViewBag.isMeet = isMeet;
            return View(r);
        }

        public IActionResult Close(int id)
        {
            Response response = db.Responses.FindById(id);
            response.Status = false;
            db.Save();
            return RedirectToAction("Details", new { id = id });
        }

        public IActionResult Open(int id)
        {
            Response response = db.Responses.FindById(id);
            response.Status = true;
            db.Save();
            return RedirectToAction("Details", new { id = id });
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Vacancies = new SelectList(db.Vacancies.Get().Where(v => v.IsArchived == false), "Id", "Title");
            ViewBag.People = (List<Person>)db.People.Get();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Response response)
        {
            response.Status = true;
            response.ResponseDate = DateTime.Now;
            db.Responses.Create(response);
            db.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            db.Vacancies.Remove(db.Vacancies.FindById(id));
            db.Save();
            return RedirectToAction("Index");
        }
    }
}
