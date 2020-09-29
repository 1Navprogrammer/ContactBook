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
    public class SocialsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private bool SocialExists(int id)
        {
            return _context.Social.Any(e => e.SId == id);
        }
        public SocialsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Socials
        public async Task<IActionResult> Index()
        {
            return View(await _context.Social.ToListAsync());
        }

        // GET: Socials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
          
            var social = await _context.Social
                .FirstOrDefaultAsync(m => m.SId == id);
        

            return View(social);
        }

        // GET: Socials/Create
        public IActionResult Create()
        {
            return View();
        }

  
        [HttpPost]
    
        public async Task<IActionResult> Create([Bind("SId,Name,InstagramId,FacebookId,WhatsappNumber")] Social social)
        {
            if (ModelState.IsValid)
            {
                _context.Add(social);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(social);
        }

        // GET: Socials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           

            var social = await _context.Social.FindAsync(id);
           
            return View(social);
        }

        // POST: Socials/Edit/5
  
        [HttpPost]
 
        public async Task<IActionResult> Edit(int id, [Bind("SId,Name,InstagramId,FacebookId,WhatsappNumber")] Social social)
        {
            if (id != social.SId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(social);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                }
                return RedirectToAction(nameof(Index));
            }
            return View(social);
        }

        // GET: Socials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
           
            var social = await _context.Social
                .FirstOrDefaultAsync(m => m.SId == id);
           

            return View(social);
        }

        // POST: Socials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var social = await _context.Social.FindAsync(id);
            _context.Social.Remove(social);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
