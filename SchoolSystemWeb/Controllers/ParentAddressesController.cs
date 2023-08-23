using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolSystemWeb.Data;
using SchoolSystemWeb.Models;

namespace SchoolSystemWeb.Controllers
{
    public class ParentAddressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParentAddressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ParentAddresses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ParentAddresses.Include(p => p.Address).Include(p => p.Parent);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ParentAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ParentAddresses == null)
            {
                return NotFound();
            }

            var parentAddress = await _context.ParentAddresses
                .Include(p => p.Address)
                .Include(p => p.Parent)
                .FirstOrDefaultAsync(m => m.ParentId == id);
            if (parentAddress == null)
            {
                return NotFound();
            }

            return View(parentAddress);
        }

        // GET: ParentAddresses/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City");
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "FirstName");
            return View();
        }

        // POST: ParentAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParentId,AddressId,DateFrom,DateTo")] ParentAddress parentAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parentAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City", parentAddress.AddressId);
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "FirstName", parentAddress.ParentId);
            return View(parentAddress);
        }

        // GET: ParentAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ParentAddresses == null)
            {
                return NotFound();
            }

            var parentAddress = await _context.ParentAddresses.FindAsync(id);
            if (parentAddress == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City", parentAddress.AddressId);
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "FirstName", parentAddress.ParentId);
            return View(parentAddress);
        }

        // POST: ParentAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParentId,AddressId,DateFrom,DateTo")] ParentAddress parentAddress)
        {
            if (id != parentAddress.ParentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parentAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParentAddressExists(parentAddress.ParentId))
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
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City", parentAddress.AddressId);
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "FirstName", parentAddress.ParentId);
            return View(parentAddress);
        }

        // GET: ParentAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ParentAddresses == null)
            {
                return NotFound();
            }

            var parentAddress = await _context.ParentAddresses
                .Include(p => p.Address)
                .Include(p => p.Parent)
                .FirstOrDefaultAsync(m => m.ParentId == id);
            if (parentAddress == null)
            {
                return NotFound();
            }

            return View(parentAddress);
        }

        // POST: ParentAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ParentAddresses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ParentAddresses'  is null.");
            }
            var parentAddress = await _context.ParentAddresses.FindAsync(id);
            if (parentAddress != null)
            {
                _context.ParentAddresses.Remove(parentAddress);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParentAddressExists(int id)
        {
          return (_context.ParentAddresses?.Any(e => e.ParentId == id)).GetValueOrDefault();
        }
    }
}
