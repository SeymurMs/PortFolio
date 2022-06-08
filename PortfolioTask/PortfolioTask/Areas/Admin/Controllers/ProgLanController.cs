using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioTask.DAL;
using PortfolioTask.Models;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProgLanController : Controller
    {
        public readonly AppDbContext _context;
        public ProgLanController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            List<ProgrammingLan> PLan = _context.programmingLans.ToList();
            return View(PLan);
        }

        // GET: ProgLanController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProgLanController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProgLanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProgrammingLan Plan)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (Plan == null) return BadRequest();

            _context.programmingLans.Add(Plan);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            ProgrammingLan Plan = _context.programmingLans.Find(id);
            if (Plan == null) return BadRequest();
           
            return View(Plan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProgrammingLan Plan)
        {
            if (!ModelState.IsValid) return BadRequest();

            ProgrammingLan DbPlan = _context.programmingLans.Find(id);
            if (DbPlan == null) return BadRequest();

            DbPlan.Name = Plan.Name;
            DbPlan.Path = Plan.Path;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            ProgrammingLan pLan = _context.programmingLans.Find(id);
            _context.programmingLans.Remove(pLan);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
