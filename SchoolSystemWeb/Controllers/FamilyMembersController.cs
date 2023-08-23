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
    public class FamilyMembersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FamilyMembersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FamilyMembers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FamilyMembers.Include(f => f.Family).Include(f => f.Student).Include(f => f.parent);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FamilyMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FamilyMembers == null)
            {
                return NotFound();
            }

            var familyMember = await _context.FamilyMembers
                .Include(f => f.Family)
                .Include(f => f.Student)
                .Include(f => f.parent)
                .FirstOrDefaultAsync(m => m.FamilyMemberId == id);
            if (familyMember == null)
            {
                return NotFound();
            }

            return View(familyMember);
        }

        // GET: FamilyMembers/Create
        public IActionResult Create()
        {
            ViewData["FamilyId"] = new SelectList(_context.Families, "FamilyId", "FamilyName");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName");
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "FirstName");
            return View();
        }

        // POST: FamilyMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FamilyMemberId,FamilyId,ParentId,StudentId")] FamilyMember familyMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(familyMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FamilyId"] = new SelectList(_context.Families, "FamilyId", "FamilyName", familyMember.FamilyId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", familyMember.StudentId);
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "FirstName", familyMember.ParentId);
            return View(familyMember);
        }

        // GET: FamilyMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FamilyMembers == null)
            {
                return NotFound();
            }

            var familyMember = await _context.FamilyMembers.FindAsync(id);
            if (familyMember == null)
            {
                return NotFound();
            }
            ViewData["FamilyId"] = new SelectList(_context.Families, "FamilyId", "FamilyName", familyMember.FamilyId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", familyMember.StudentId);
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "FirstName", familyMember.ParentId);
            return View(familyMember);
        }

        // POST: FamilyMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FamilyMemberId,FamilyId,ParentId,StudentId")] FamilyMember familyMember)
        {
            if (id != familyMember.FamilyMemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(familyMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamilyMemberExists(familyMember.FamilyMemberId))
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
            ViewData["FamilyId"] = new SelectList(_context.Families, "FamilyId", "FamilyName", familyMember.FamilyId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", familyMember.StudentId);
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "FirstName", familyMember.ParentId);
            return View(familyMember);
        }

        // GET: FamilyMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FamilyMembers == null)
            {
                return NotFound();
            }

            var familyMember = await _context.FamilyMembers
                .Include(f => f.Family)
                .Include(f => f.Student)
                .Include(f => f.parent)
                .FirstOrDefaultAsync(m => m.FamilyMemberId == id);
            if (familyMember == null)
            {
                return NotFound();
            }

            return View(familyMember);
        }

        // POST: FamilyMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FamilyMembers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FamilyMembers'  is null.");
            }
            var familyMember = await _context.FamilyMembers.FindAsync(id);
            if (familyMember != null)
            {
                _context.FamilyMembers.Remove(familyMember);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamilyMemberExists(int id)
        {
          return (_context.FamilyMembers?.Any(e => e.FamilyMemberId == id)).GetValueOrDefault();
        }
    }
}
