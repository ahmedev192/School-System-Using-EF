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
    public class StudentParentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentParentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentParents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentParents.Include(s => s.Parent).Include(s => s.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentParents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentParents == null)
            {
                return NotFound();
            }

            var studentParent = await _context.StudentParents
                .Include(s => s.Parent)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentParent == null)
            {
                return NotFound();
            }

            return View(studentParent);
        }

        // GET: StudentParents/Create
        public IActionResult Create()
        {
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "FirstName");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName");
            return View();
        }

        // POST: StudentParents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,ParentId")] StudentParent studentParent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentParent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "FirstName", studentParent.ParentId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", studentParent.StudentId);
            return View(studentParent);
        }

        // GET: StudentParents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentParents == null)
            {
                return NotFound();
            }

            var studentParent = await _context.StudentParents.FindAsync(id);
            if (studentParent == null)
            {
                return NotFound();
            }
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "FirstName", studentParent.ParentId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", studentParent.StudentId);
            return View(studentParent);
        }

        // POST: StudentParents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,ParentId")] StudentParent studentParent)
        {
            if (id != studentParent.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentParent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentParentExists(studentParent.StudentId))
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
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "FirstName", studentParent.ParentId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", studentParent.StudentId);
            return View(studentParent);
        }

        // GET: StudentParents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentParents == null)
            {
                return NotFound();
            }

            var studentParent = await _context.StudentParents
                .Include(s => s.Parent)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentParent == null)
            {
                return NotFound();
            }

            return View(studentParent);
        }

        // POST: StudentParents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentParents == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentParents'  is null.");
            }
            var studentParent = await _context.StudentParents.FindAsync(id);
            if (studentParent != null)
            {
                _context.StudentParents.Remove(studentParent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentParentExists(int id)
        {
          return (_context.StudentParents?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
