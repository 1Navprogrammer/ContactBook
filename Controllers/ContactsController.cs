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
     // Contacts Controller Handles CRUD operations
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _AppDBContext;

        public ContactsController(ApplicationDbContext context)
        {
            _AppDBContext = context;
        }      
        public async Task<IActionResult> Index() // Default index action 
        {
            // returns the list of contacts to view
            return View(await _AppDBContext.tContacts.ToListAsync());
        }
        // get action method for default create view
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // http post request to create
        public async Task<IActionResult> Create([Bind("CID,FName,LName,Email,Cell,Facebook,PermanentAddress")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                _AppDBContext.Add(contacts);
                await _AppDBContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contacts);
        }
        // Action Edit
        public async Task<IActionResult> Edit(int? id) // Edit by id
        {

            var contacts = await _AppDBContext.tContacts.FindAsync(id);
            return View(contacts);
        }

        [HttpPost] // httt post request to edit by id
        public async Task<IActionResult> Edit(int id, [Bind("CID,FName,LName,Email,Cell,Facebook,PermanentAddress")] Contacts contacts)
        {
          
            if (ModelState.IsValid)
            {
                try
                {
                    _AppDBContext.Update(contacts);
                    await _AppDBContext.SaveChangesAsync();
                }
                catch (Exception)
                {
                   
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contacts);
        }
        private bool ContactsExists(int id) // Check if contacts exists
        {
            return _AppDBContext.tContacts.Any(e => e.CID == id);
        }
        //action Delete
        public async Task<IActionResult> Delete(int? id)
        {
            
            var contacts = await _AppDBContext.tContacts
                .FirstOrDefaultAsync(m => m.CID == id);
            return View(contacts);
        }

        [HttpPost, ActionName("Delete")] // delete confirm method
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contacts = await _AppDBContext.tContacts.FindAsync(id);
            _AppDBContext.tContacts.Remove(contacts);
            await _AppDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
