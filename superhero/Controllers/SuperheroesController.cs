using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using superhero.Data;
using superhero.Models;

namespace superhero.Controllers
{
    public class SuperheroesController : Controller
    {
        ApplicationDbContext _context;
        public SuperheroesController(ApplicationDbContext context)
        {
            _context = context;      
        }
        // GET: Superheroes
        public ActionResult Index()
        {
            return View(_context.Superheroes);
        }

        // GET: Superheroes/Details/5
        public ActionResult Details(int id)
        {
            var superhero = _context.Superheroes.Find(id); 
            return View(superhero);
        }

        // GET: Superheroes/Create
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View(superhero);
        }

        // POST: Superheroes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Superheroes.Add(superhero);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(superhero);
                
            }
            catch
            {
                return View(superhero);
            }
        }

        // GET: Superheroes/Edit/5
        public ActionResult Edit(int id)
        {
            var superhero = _context.Superheroes.Find(id);
            return View(superhero);
        }

        // POST: Superheroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                Superhero heroFromDb = _context.Superheroes.Find(id);
                heroFromDb.Name = superhero.Name;
                heroFromDb.AlterEgo = superhero.AlterEgo;
                heroFromDb.PrimaryAbility = superhero.PrimaryAbility;
                heroFromDb.SecondaryAbility = superhero.SecondaryAbility;
                heroFromDb.CatchPhrase = superhero.CatchPhrase;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheroes/Delete/5
        public ActionResult Delete(int id)
        {
            var superhero = _context.Superheroes.Find(id);
            return View(superhero);
        }

        // POST: Superheroes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                _context.Superheroes.Remove(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}