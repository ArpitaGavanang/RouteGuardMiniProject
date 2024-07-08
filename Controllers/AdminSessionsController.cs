using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RouteGuardProject.Models;

namespace RouteGuardProject.Controllers
{
    public class AdminSessionsController : Controller
    {
        private readonly LogisticContext _context;

        public AdminSessionsController(LogisticContext context)
        {
            _context = context;
        }

        // GET: AdminSessions
        public async Task<IActionResult> Index()
        {
            var logisticContext = _context.AdminSessions.Include(a => a.Admin);
            return View(await logisticContext.ToListAsync());
        }

        // GET: AdminSessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminSession = await _context.AdminSessions
                .Include(a => a.Admin)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminSession == null)
            {
                return NotFound();
            }

            return View(adminSession);
        }

        // GET: AdminSessions/Create
        public IActionResult Create()
        {
            ViewData["AdminId"] = new SelectList(_context.Admins, "Id", "Id");
            return View();
        }

        // POST: AdminSessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdminId,Token,LoginAt")] AdminSession adminSession)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminId"] = new SelectList(_context.Admins, "Id", "Id", adminSession.AdminId);
            return View(adminSession);
        }

        // GET: AdminSessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminSession = await _context.AdminSessions.FindAsync(id);
            if (adminSession == null)
            {
                return NotFound();
            }
            ViewData["AdminId"] = new SelectList(_context.Admins, "Id", "Id", adminSession.AdminId);
            return View(adminSession);
        }

        // POST: AdminSessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdminId,Token,LoginAt")] AdminSession adminSession)
        {
            if (id != adminSession.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminSession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminSessionExists(adminSession.Id))
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
            ViewData["AdminId"] = new SelectList(_context.Admins, "Id", "Id", adminSession.AdminId);
            return View(adminSession);
        }

        // GET: AdminSessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminSession = await _context.AdminSessions
                .Include(a => a.Admin)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminSession == null)
            {
                return NotFound();
            }

            return View(adminSession);
        }

        // POST: AdminSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminSession = await _context.AdminSessions.FindAsync(id);
            if (adminSession != null)
            {
                _context.AdminSessions.Remove(adminSession);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminSessionExists(int id)
        {
            return _context.AdminSessions.Any(e => e.Id == id);
        }
    }
}
