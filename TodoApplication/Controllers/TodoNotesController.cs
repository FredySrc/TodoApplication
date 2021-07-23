using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoApplication.Data;
using TodoApplication.Models;

namespace TodoApplication.Controllers
{
    public class TodoNotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TodoNotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TodoNotes
        public async Task<IActionResult> Index(string search)
        {
            if (search == null)
            {
                return View(await _context.TodoNotes
                    .Include(t => t.Categorie)
                    .ToListAsync());
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID");
            var applicationDbContext = _context.TodoNotes
                .Include(t => t.Categorie)
                .Where(t => t.Categorie.CategoryName.Contains(search));
            return View(await applicationDbContext.ToListAsync());
        }
        
        
        // GET: TodoNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoNote = await _context.TodoNotes
                .Include(t => t.Categorie)
                .FirstOrDefaultAsync(m => m.TodoNoteID == id);
            if (todoNote == null)
            {
                return NotFound();
            }

            return View(todoNote);
        }

        // GET: TodoNotes/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: TodoNotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TodoNote todoNote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todoNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", todoNote.CategoryID);
            return View(todoNote);
        }

        // GET: TodoNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoNote = await _context.TodoNotes.FindAsync(id);
            if (todoNote == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", todoNote.CategoryID);
            return View(todoNote);
        }

        // POST: TodoNotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TodoNote todoNote)
        {
            if (id != todoNote.TodoNoteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todoNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoNoteExists(todoNote.TodoNoteID))
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
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", todoNote.CategoryID);
            return View(todoNote);
        }

        // GET: TodoNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoNote = await _context.TodoNotes
                .Include(t => t.Categorie)
                .FirstOrDefaultAsync(m => m.TodoNoteID == id);
            if (todoNote == null)
            {
                return NotFound();
            }

            return View(todoNote);
        }

        // POST: TodoNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todoNote = await _context.TodoNotes.FindAsync(id);
            _context.TodoNotes.Remove(todoNote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodoNoteExists(int id)
        {
            return _context.TodoNotes.Any(e => e.TodoNoteID == id);
        }
    }
}
