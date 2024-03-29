﻿using System;
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
    public class StudentClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentClasses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentClasses.Include(s => s.Class).Include(s => s.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentClasses == null)
            {
                return NotFound();
            }

            var studentClass = await _context.StudentClasses
                .Include(s => s.Class)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentClass == null)
            {
                return NotFound();
            }

            return View(studentClass);
        }

        // GET: StudentClasses/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName");
            return View();
        }

        // POST: StudentClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,ClassId,DateFrom,DateTo")] StudentClass studentClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName", studentClass.ClassId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", studentClass.StudentId);
            return View(studentClass);
        }

        // GET: StudentClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentClasses == null)
            {
                return NotFound();
            }

            var studentClass = await _context.StudentClasses.FindAsync(id);
            if (studentClass == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName", studentClass.ClassId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", studentClass.StudentId);
            return View(studentClass);
        }

        // POST: StudentClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,ClassId,DateFrom,DateTo")] StudentClass studentClass)
        {
            if (id != studentClass.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentClassExists(studentClass.StudentId))
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
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName", studentClass.ClassId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", studentClass.StudentId);
            return View(studentClass);
        }

        // GET: StudentClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentClasses == null)
            {
                return NotFound();
            }

            var studentClass = await _context.StudentClasses
                .Include(s => s.Class)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentClass == null)
            {
                return NotFound();
            }

            return View(studentClass);
        }

        // POST: StudentClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentClasses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentClasses'  is null.");
            }
            var studentClass = await _context.StudentClasses.FindAsync(id);
            if (studentClass != null)
            {
                _context.StudentClasses.Remove(studentClass);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentClassExists(int id)
        {
          return (_context.StudentClasses?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
