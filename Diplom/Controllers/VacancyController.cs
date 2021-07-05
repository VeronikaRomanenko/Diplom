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
    public class VacancyController : Controller
    {
        private IUnitOfWork db;

        public VacancyController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Vacancies.Get());
        }

        public IActionResult Details(int id)
        {
            Vacancy v = db.Vacancies.FindById(id);
            ViewBag.Responses = v.Responses.OrderByDescending(i => i.Status);
            return View(v);
        }

        public IActionResult Close(int id)
        {
            Vacancy vacancy = db.Vacancies.FindById(id);
            vacancy.IsArchived = true;
            vacancy.EndDate = DateTime.Now;
            db.Save();
            return RedirectToAction("Details", new { id = id });
        }

        public IActionResult Open(int id)
        {
            Vacancy vacancy = db.Vacancies.FindById(id);
            vacancy.IsArchived = false;
            db.Save();
            return RedirectToAction("Details", new { id = id });
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Disciplines = (List<Discipline>)db.Disciplines.Get();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Vacancy vacancy, int[] selectedDisciplines)
        {
            if (selectedDisciplines != null)
            {
                foreach (var item in db.Disciplines.Get().Where(t => selectedDisciplines.Contains(t.Id)))
                {
                    vacancy.Disciplines.Add(item);
                }
            }
            vacancy.IsArchived = false;
            vacancy.StartDate = DateTime.Now;
            db.Vacancies.Create(vacancy);
            db.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Disciplines = (List<Discipline>)db.Disciplines.Get();
            return View(db.Vacancies.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Vacancy vacancy, int[] selectedDisciplines)
        {
            Vacancy newVacancy = db.Vacancies.FindById(vacancy.Id);
            newVacancy.Title = vacancy.Title;
            newVacancy.Description = vacancy.Description;
            newVacancy.StartDate = vacancy.StartDate;
            newVacancy.EndDate = vacancy.EndDate;

            newVacancy.Disciplines.Clear();
            if (selectedDisciplines != null)
            {
                foreach (var item in db.Disciplines.Get().Where(t => selectedDisciplines.Contains(t.Id)))
                {
                    newVacancy.Disciplines.Add(item);
                }
            }
            db.Vacancies.Update(newVacancy);
            db.Save();
            return RedirectToAction("Details", new { id = vacancy.Id });
        }

        public IActionResult Remove(int id)
        {
            db.Vacancies.Remove(db.Vacancies.FindById(id));
            db.Save();
            return RedirectToAction("Index");
        }
    }
}
