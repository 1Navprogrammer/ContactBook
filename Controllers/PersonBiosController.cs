using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactBook.Data;
using ContactBook.Models;

namespace ContactBook.Controllers
{
    public class PersonBiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonBiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonBios
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonBio.ToListAsync());
        }

        // GET: PersonBios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
          

            var personBio = await _context.PersonBio
                .FirstOrDefaultAsync(m => m.PBID == id);
           

            return View(personBio);
        }

        // GET: PersonBios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonBios/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PBID,FullName,Hobbies,Bloodgroup")] PersonBio personBio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personBio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personBio);
        }

        // GET: PersonBios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var personBio = await _context.PersonBio.FindAsync(id);
         
            return View(personBio);
        }

        // POST: PersonBios/Edit/5
    
        [HttpPost]

        public async Task<IActionResult> Edit(int id, [Bind("PBID,FullName,Hobbies,Bloodgroup")] PersonBio personBio)
        {
            if (id != personBio.PBID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personBio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonBioExists(personBio.PBID))
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
            return View(personBio);
        }

        // GET: PersonBios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personBio = await _context.PersonBio
                .FirstOrDefaultAsync(m => m.PBID == id);
            if (personBio == null)
            {
                return NotFound();
            }

            return View(personBio);
        }

        // POST: PersonBios/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personBio = await _context.PersonBio.FindAsync(id);
            _context.PersonBio.Remove(personBio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonBioExists(int id)
        {
            return _context.PersonBio.Any(e => e.PBID == id);
        }
    }
}
