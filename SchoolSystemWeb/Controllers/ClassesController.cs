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
    public class ClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Classes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Classes.Include(u => u.Subject).Include(u => u.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Classes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var uclass = await _context.Classes
                .Include(u => u.Subject)
                .Include(u => u.Teacher)
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (uclass == null)
            {
                return NotFound();
            }

            return View(uclass);
        }

        // GET: Classes/Create
        public IActionResult Create()
        {
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "FirstName");
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassId,SubjectId,TeacherId,ClassName,DateFrom,DateTo")] Class uclass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uclass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName", uclass.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "FirstName", uclass.TeacherId);
            return View(uclass);
        }

        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var uclass = await _context.Classes.FindAsync(id);
            if (uclass == null)
            {
                return NotFound();
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName", uclass.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "FirstName", uclass.TeacherId);
            return View(uclass);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassId,SubjectId,TeacherId,ClassName,DateFrom,DateTo")] Class uclass)
        {
            if (id != uclass.ClassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uclass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(uclass.ClassId))
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
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName", uclass.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "FirstName", uclass.TeacherId);
            return View(uclass);
        }

        // GET: Classes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var uclass = await _context.Classes
                .Include(u => u.Subject)
                .Include(u => u.Teacher)
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (uclass == null)
            {
                return NotFound();
            }

            return View(uclass);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Classes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Classes'  is null.");
            }
            var uclass = await _context.Classes.FindAsync(id);
            if (uclass != null)
            {
                _context.Classes.Remove(uclass);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassExists(int id)
        {
          return (_context.Classes?.Any(e => e.ClassId == id)).GetValueOrDefault();
        }
    }
}
