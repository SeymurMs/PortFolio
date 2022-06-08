using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioTask.DAL;
using PortfolioTask.Models;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillsController : Controller
    {
        public readonly AppDbContext _context;
        public SkillsController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            List<Skills> skills = _context.skills.Include(s=>s.ProgLan).Include(si=>si.WorkFlows).ToList();
            return View(skills);
        }

       

        public ActionResult Create()
        {
            ViewBag.Proglan = _context.programmingLans.ToList();
            ViewBag.WorkFlows = _context.workFlows.ToList();
            return View();
        }

        // POST: SkillsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Skills skills)
        {
            ViewBag.Proglan = _context.programmingLans.ToList();
            ViewBag.WorkFlows = _context.workFlows.ToList();

            if (!ModelState.IsValid) return BadRequest();


            _context.skills.Add(skills);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }

        // GET: SkillsController/Edit/5
        public ActionResult Edit(int id)
        {
            Skills skil = _context.skills.Include(p => p.ProgLan).Include(w => w.WorkFlows).SingleOrDefault(i => i.Id == id);
            ViewBag.Proglan = _context.programmingLans.ToList();
            ViewBag.WorkFlows = _context.workFlows.ToList();
            return View(skil);
        }

        // POST: SkillsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Skills skill)
        {
            ViewBag.Proglan = _context.programmingLans.ToList();
            ViewBag.WorkFlows = _context.workFlows.ToList();
            if (skill.Id != id) return BadRequest();

            Skills DbSkill = _context.skills.Find(id);
            List<ProgrammingLan> Plan = _context.programmingLans.Where(p => p.Id == skill.ProgrammingLanId).ToList();
            List<WorkFlows> wk = _context.workFlows.Where(w => w.Id == skill.WorkFlowsId).ToList();
            if (skill.WorkFlowsId!=0  || skill.ProgrammingLanId !=0 )
            {
                DbSkill.WorkFlowsId = skill.WorkFlowsId;
                DbSkill.ProgrammingLanId = skill.ProgrammingLanId;
            }
            DbSkill.Title = skill.Title;
            _context.SaveChanges();
            return RedirectToAction("Index");
                    
        }

        // GET: SkillsController/Delete/5
        public ActionResult Delete(int id)
        {
            Skills skil = _context.skills.Find(id);
            if (skil == null) return BadRequest();
            _context.skills.Remove(skil);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        
    }
}
