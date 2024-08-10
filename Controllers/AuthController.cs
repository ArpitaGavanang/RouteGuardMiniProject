using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteGuardProject.Models;
using RouteGuardProject.ViewModels;

namespace RouteGuardProject.Controllers
{
    public class AuthController : Controller
    {
        
            private readonly LogisticContext _context;

            public AuthController(LogisticContext context)
            {
                _context = context;
            }

            // GET: Auth/Signup
            public IActionResult Signup()
            {
                return View();
            }

            // POST: Auth/Signup
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Signup(SignupViewModel model)
            {
                if (ModelState.IsValid)
                {
                    // Create SuperAdmin or Admin based on some condition
                    if (model.Role == "SuperAdmin")
                    {
                        var superAdmin = new SuperAdmin
                        {
                            Name = model.Name,
                            Department = model.Department,
                            Designation = model.Designation,
                            Dob = model.DOB,
                            Role = model.Role,
                            JoinDate = model.JoinDate,
                            // Store hashed password
                        };
                        _context.Add(superAdmin);
                    }
                    else
                    {
                        var admin = new Admin
                        {
                            Name = model.Name,
                            Department = model.Department,
                            Designation = model.Designation,
                            Dob = model.DOB,
                            Role = model.Role,
                            JoinDate = model.JoinDate,
                            Permissions = "Default Permissions", // Or set dynamically
                            CreatedBy = "Super Admin",
                            CreatedAt = "Super Admin",
                            Password = model.Password
                            // Store hashed password
                        };
                        _context.Add(admin);
                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index","Admins");
                }
                return View(model);
            }

            // GET: Auth/Login
            public IActionResult Login()
            {
                return View();
            }

            // POST: Auth/Login
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Login(LoginViewModel model)
            {
                if (ModelState.IsValid)
                {
                    var superAdmin = await _context.SuperAdmins
                        .FirstOrDefaultAsync(sa => sa.Name == model.Name && sa.Password == model.Password);
                    var admin = await _context.Admins
                        .FirstOrDefaultAsync(a => a.Name == model.Name && a.Password == model.Password);

                    if (superAdmin != null)
                    {
                        var session = new SuperAdminSession
                        {
                            SuperAdminId = superAdmin.Id,
                            Token = GenerateToken(),
                            LoginAt = DateTime.Now
                        };
                        _context.Add(session);
                        await _context.SaveChangesAsync();
                        // Redirect to SuperAdmin dashboard
                        return RedirectToAction("Index", "Admins");
                    }
                    else if (admin != null)
                    {
                        var session = new AdminSession
                        {
                            AdminId = admin.Id,
                            Token = GenerateToken(),
                            LoginAt = DateTime.Now
                        };
                        _context.Add(session);
                        await _context.SaveChangesAsync();
                        // Redirect to Admin dashboard
                        return RedirectToAction("Index", "VehicleRouteTables");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    }
                }
                return View(model);
            }

            private string GenerateToken()
            {
                return Guid.NewGuid().ToString();
            }
        }
    }

