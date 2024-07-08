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
    public class SuperAdminSessionsController : Controller
    {
        private readonly LogisticContext _context;

        public SuperAdminSessionsController(LogisticContext context)
        {
            _context = context;
        }

        // GET: SuperAdminSessions
        public async Task<IActionResult> Index()
        {
            var logisticContext = _context.SuperAdminSessions.Include(s => s.SuperAdmin);
            return View(await logisticContext.ToListAsync());
        }

        // GET: SuperAdminSessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superAdminSession = await _context.SuperAdminSessions
                .Include(s => s.SuperAdmin)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superAdminSession == null)
            {
                return NotFound();
            }

            return View(superAdminSession);
        }

        // GET: SuperAdminSessions/Create
        public IActionResult Create()
        {
            ViewData["SuperAdminId"] = new SelectList(_context.SuperAdmins, "Id", "Id");
            return View();
        }

        // POST: SuperAdminSessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SuperAdminId,Token,LoginAt")] SuperAdminSession superAdminSession)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superAdminSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SuperAdminId"] = new SelectList(_context.SuperAdmins, "Id", "Id", superAdminSession.SuperAdminId);
            return View(superAdminSession);
        }

        // GET: SuperAdminSessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superAdminSession = await _context.SuperAdminSessions.FindAsync(id);
            if (superAdminSession == null)
            {
                return NotFound();
            }
            ViewData["SuperAdminId"] = new SelectList(_context.SuperAdmins, "Id", "Id", superAdminSession.SuperAdminId);
            return View(superAdminSession);
        }

        // POST: SuperAdminSessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SuperAdminId,Token,LoginAt")] SuperAdminSession superAdminSession)
        {
            if (id != superAdminSession.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superAdminSession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuperAdminSessionExists(superAdminSession.Id))
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
            ViewData["SuperAdminId"] = new SelectList(_context.SuperAdmins, "Id", "Id", superAdminSession.SuperAdminId);
            return View(superAdminSession);
        }

        // GET: SuperAdminSessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superAdminSession = await _context.SuperAdminSessions
                .Include(s => s.SuperAdmin)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superAdminSession == null)
            {
                return NotFound();
            }

            return View(superAdminSession);
        }

        // POST: SuperAdminSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var superAdminSession = await _context.SuperAdminSessions.FindAsync(id);
            if (superAdminSession != null)
            {
                _context.SuperAdminSessions.Remove(superAdminSession);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuperAdminSessionExists(int id)
        {
            return _context.SuperAdminSessions.Any(e => e.Id == id);
        }
    }
}
