using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioTask.DAL;
using PortfolioTask.Models;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExperiencesController : Controller
    {
        private readonly AppDbContext _context;
        public ExperiencesController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            List<Experience> ex =_context.experiences.ToList();
            return View(ex);
        }
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExperiencesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExperiencesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Experience experiences)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (experiences == null)
            {
                return BadRequest();
            }
            _context.experiences.Add(experiences);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }

        // GET: ExperiencesController/Edit/5
        public ActionResult Edit(int id)
        {
            Experience ex = _context.experiences.Find(id);
            if (ex == null) return BadRequest();
          
            return View(ex);
        }

        // POST: ExperiencesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Experience ex)
        {
            if (!ModelState.IsValid) return BadRequest();

            Experience dbExperience = _context.experiences.Find(id);
            if (dbExperience == null) return BadRequest();

            dbExperience.Name = ex.Name;
            dbExperience.Title = ex.Title;
            dbExperience.Description = ex.Description;
            dbExperience.Date = ex.Date;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: ExperiencesController/Delete/5
        public ActionResult Delete(int id)
        {
            Experience DeleteEx = _context.experiences.Find(id);
            _context.experiences.Remove(DeleteEx);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
