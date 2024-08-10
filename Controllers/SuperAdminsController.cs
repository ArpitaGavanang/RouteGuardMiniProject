using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RouteGuardProject.Models;
using RouteGuardProject.ViewModels;

namespace RouteGuardProject.Controllers
{
    public class SuperAdminsController : Controller
    {
        private readonly LogisticContext _context;

        public SuperAdminsController(LogisticContext context)
        {
            _context = context;
        }

        // GET: SuperAdmins
        public async Task<IActionResult> Index()
        {
            return View(await _context.SuperAdmins.ToListAsync());
        }

        // GET: SuperAdmins/Details/5
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var superAdmin = await _context.SuperAdmins
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (superAdmin == null)
            {
                return NotFound();
            }

            return View(superAdmin);
        }

        // GET: SuperAdmins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuperAdmins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Role,Department,Designation,Dob,JoinDate,Password")] SuperAdmin superAdmin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superAdmin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(superAdmin);
        }

        // GET: SuperAdmins/Edit/5
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var superAdmin = await _context.SuperAdmins.FindAsync(Id);
            if (superAdmin == null)
            {
                return NotFound();
            }
            return View(superAdmin);
        }

        // POST: SuperAdmins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("Id,Name,Role,Department,Designation,Dob,JoinDate,Password")] SuperAdmin superAdmin)
        {
            if (Id != superAdmin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superAdmin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuperAdminExists(superAdmin.Id))
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
            return View(superAdmin);
        }

        // GET: SuperAdmins/Delete/5
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var superAdmin = await _context.SuperAdmins
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (superAdmin == null)
            {
                return NotFound();
            }

            return View(superAdmin);
        }

        // POST: SuperAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var superAdmin = await _context.SuperAdmins.FindAsync(Id);
            if (superAdmin != null)
            {
                _context.SuperAdmins.Remove(superAdmin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuperAdminExists(int Id)
        {
            return _context.SuperAdmins.Any(e => e.Id == Id);
        }

        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var superAdminId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "SuperAdminId").Value);
        //    var superAdmin = await _context.SuperAdmins.FindAsync(superAdminId);

        //    if (superAdmin == null || superAdmin.Password != model.OldPassword)
        //    {
        //        ModelState.AddModelError(string.Empty, "Old password is incorrect.");
        //        return View(model);
        //    }

        //    superAdmin.Password = model.NewPassword;
        //    _context.SuperAdmins.Update(superAdmin);
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction("Index", "Home");
        //}
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var superAdminClaim = User.Claims.FirstOrDefault(c => c.Type == "SuperAdminId");
            if (superAdminClaim == null)
            {
                ModelState.AddModelError(string.Empty, "SuperAdminId claim not found.");
                return View(model);
            }

            if (string.IsNullOrEmpty(superAdminClaim.Value))
            {
                ModelState.AddModelError(string.Empty, "SuperAdminId claim value is empty.");
                return View(model);
            }

            if (!int.TryParse(superAdminClaim.Value, out var superAdminId))
            {
                ModelState.AddModelError(string.Empty, "Invalid SuperAdminId claim value.");
                return View(model);
            }

            var superAdmin = await _context.SuperAdmins.FindAsync(superAdminId);
            if (superAdmin == null || superAdmin.Password != model.OldPassword)
            {
                ModelState.AddModelError(string.Empty, "Old password is incorrect.");
                return View(model);
            }

            superAdmin.Password = model.NewPassword;
            _context.SuperAdmins.Update(superAdmin);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

    }
}
