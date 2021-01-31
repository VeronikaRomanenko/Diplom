using Diplom.Models;
using Diplom.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Controllers
{
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
            db.Vacancies.Create(vacancy);
            db.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Disciplines = (List<Discipline>)db.Disciplines.Get();
            return View(db.Disciplines.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Vacancy vacancy, int[] selectedDisciplines)
        {
            Vacancy newVacancy = db.Vacancies.FindById(vacancy.Id);
            newVacancy.Title = vacancy.Title;
            newVacancy.Description = vacancy.Description;
            newVacancy.IsArchived = vacancy.IsArchived;
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
