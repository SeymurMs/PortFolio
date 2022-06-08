using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioTask.DAL;
using PortfolioTask.Models;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EducationController : Controller   
    {
        public readonly AppDbContext _context;
        public EducationController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EducationController
        public ActionResult Index()
        {
            List<Education> ed = _context.educations.ToList();
            return View(ed);
        }

        // GET: EducationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EducationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EducationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Education education)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (education == null) return BadRequest();

            _context.educations.Add(education);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: EducationController/Edit/5
        public ActionResult Edit(int id)
        {
            Education edu = _context.educations.Find(id);
            if (edu == null) return BadRequest();
                        
             return View(edu);
        }

        // POST: EducationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Education edu)
        {
            if (!ModelState.IsValid) return BadRequest();

            Education dbEdu = _context.educations.Find(id);
            if (dbEdu == null) return BadRequest();

            dbEdu.Title = edu.Title;
            dbEdu.Name = edu.Name;
            dbEdu.Description = edu.Description;
            dbEdu.Raiting = edu.Raiting;
            dbEdu.Date = edu.Date;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: EducationController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            return BadRequest();

            Education ed = _context.educations.Find(id);
            if (ed == null) return BadRequest();

            _context.educations.Remove(ed);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
