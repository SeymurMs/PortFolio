using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioTask.DAL;
using PortfolioTask.Models;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkFlowController : Controller
    {
        public readonly AppDbContext _context;
        public WorkFlowController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            List<WorkFlows> wk = _context.workFlows.ToList();
            return View(wk);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkFlows wk)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (wk == null) return BadRequest();

            _context.workFlows.Add(wk);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            WorkFlows wk = _context.workFlows.Find(id);

            return View(wk);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WorkFlows wk)
        {
            if (wk == null) return BadRequest();
            WorkFlows dbWk = _context.workFlows.Find(id);
            if (dbWk == null) return BadRequest();

            dbWk.Name = wk.Name;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            
            
        }

        // GET: WorkFlowController/Delete/5
        public ActionResult Delete(int id)
        {
            WorkFlows wk = _context.workFlows.Find(id);
            if (wk == null) return BadRequest();
            _context.workFlows.Remove(wk);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
