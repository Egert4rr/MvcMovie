using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class ActorsController : Controller
    {
        private readonly MvcMovieContext _context;

        public ActorsController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Actors
        public async Task<IActionResult> Index(string Skill, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> SkillQuery = from m in _context.Actors
                                            orderby m.Firstname
                                            select m.Skills;

            var Actors = from m in _context.Actors
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                Actors = Actors.Where(s => s.Firstname.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(Skill))
            {
                Actors = Actors.Where(x => x.Skills == Skill);
            }

            var ActorSkillVM = new ActorsSkillsModel
            {
                Skills = new SelectList(await SkillQuery.Distinct().ToListAsync()),
                Actors = await Actors.ToListAsync()
            };

            return View(ActorSkillVM);
        }

        // GET: Actors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actors = await _context.Actors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actors == null)
            {
                return NotFound();
            }

            return View(actors);
        }

        // GET: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Firstname,Lastname,BirthDay,Skills,Networth")] Actors actors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actors);
        }

        // GET: Actors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actors = await _context.Actors.FindAsync(id);
            if (actors == null)
            {
                return NotFound();
            }
            return View(actors);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Firstname,Lastname,BirthDay,Skills,Networth")] Actors actors)
        {
            if (id != actors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorsExists(actors.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(actors);
        }

        // GET: Actors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actors = await _context.Actors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actors == null)
            {
                return NotFound();
            }

            return View(actors);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actors = await _context.Actors.FindAsync(id);
            _context.Actors.Remove(actors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorsExists(int id)
        {
            return _context.Actors.Any(e => e.Id == id);
        }
    }
}
