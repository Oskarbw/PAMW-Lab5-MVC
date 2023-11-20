using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PAMW5_MVC.DataAccess;
using PAMW5_MVC.Models;

namespace PAMW5_MVC.Controllers
{
    public class ParcelsController : Controller
    {
        private readonly PostOfficeContext _context;

        public ParcelsController(PostOfficeContext context)
        {
            _context = context;
        }

        // GET: Parcels
        public async Task<IActionResult> Index()
        {
              return _context.Parcels != null ? 
                          View(await _context.Parcels.ToListAsync()) :
                          Problem("Entity set 'PostOfficeContext.Parcels'  is null.");
        }

        // GET: Parcels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Parcels == null)
            {
                return NotFound();
            }

            var parcel = await _context.Parcels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parcel == null)
            {
                return NotFound();
            }

            return View(parcel);
        }

        // GET: Parcels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parcels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sender,Receiver,Weight")] Parcel parcel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parcel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parcel);
        }

        // GET: Parcels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Parcels == null)
            {
                return NotFound();
            }

            var parcel = await _context.Parcels.FindAsync(id);
            if (parcel == null)
            {
                return NotFound();
            }
            return View(parcel);
        }

        // POST: Parcels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sender,Receiver,Weight")] Parcel parcel)
        {
            if (id != parcel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parcel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParcelExists(parcel.Id))
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
            return View(parcel);
        }

        // GET: Parcels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Parcels == null)
            {
                return NotFound();
            }

            var parcel = await _context.Parcels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parcel == null)
            {
                return NotFound();
            }

            return View(parcel);
        }

        // POST: Parcels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Parcels == null)
            {
                return Problem("Entity set 'PostOfficeContext.Parcels'  is null.");
            }
            var parcel = await _context.Parcels.FindAsync(id);
            if (parcel != null)
            {
                _context.Parcels.Remove(parcel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParcelExists(int id)
        {
          return (_context.Parcels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
