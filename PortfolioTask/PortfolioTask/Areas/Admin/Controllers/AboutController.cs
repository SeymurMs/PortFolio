using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioTask.DAL;
using PortfolioTask.Models;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            List<About> about  = _context.About.ToList();
            return View(about);
        }

      

        // GET: AboutController/Create
        public ActionResult Create()
        {
            if (_context.About.Count() == 1)
            {
                return BadRequest();
            }
            return View();
        }

        // POST: AboutController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(About about)
        {
            if (!ModelState.IsValid) return View();
            About ab = _context.About.FirstOrDefault(b => b.Title.ToLower().Trim().Contains(about.Title.ToLower().Trim()));
            _context.About.Add(about);
            _context.SaveChanges();
           return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            About DbAb = _context.About.Find(id);
            if (DbAb == null)
            {
                return BadRequest();

            }
            return View(DbAb);
        }

        // POST: AboutController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, About about)
        {
            if (about == null)
            {
                return BadRequest();
            }
            About abItem = _context.About.Find(id);
            if (abItem == null)
            {
                return BadRequest();
            }
            abItem.Title = about.Title;
            abItem.Description = about.Description;
            abItem.Email = about.Email;
            abItem.Address = about.Address;
            abItem.Number = about.Number;
            abItem.Facebook = about.Facebook;
            abItem.LinkEdin = about.LinkEdin;
            abItem.Github = about.Github;
            abItem.Twitter = about.Twitter;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            About dbAbout = _context.About.Find(id);
            _context.About.Remove(dbAbout);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index)); 
        }

      
    }
}
