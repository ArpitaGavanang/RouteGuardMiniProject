using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RouteGuardProject.Models;

namespace RouteGuardProject.Controllers
{
    public class SuperAdminLoginsController : Controller
    {
        private readonly LogisticContext _context; // Adjust the DbContext name

        public  SuperAdminLoginsController(LogisticContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string name, string Password)
        {
            var superAdmin = _context.SuperAdmins
                .FirstOrDefault(sa => sa.Name == name && sa.Password == Password);

            if (superAdmin != null)
            {
                var session = new SuperAdminSession
                {
                    SuperAdminId = superAdmin.Id,
                    Token = Guid.NewGuid().ToString(),
                    LoginAt = DateTime.Now
                };
                _context.SuperAdminSessions.Add(session);
                _context.SaveChanges();

                // Set the session or authentication token as required
                // e.g., HttpContext.Session.SetString("SuperAdminToken", session.Token);
                // Or use a more secure authentication mechanism

                return RedirectToAction("Index", "Admins"); // Adjust redirection as needed
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View();


            //// GET: SuperAdminLoginsController
            //public ActionResult Index()
            //{
            //    return View();
            //}

            //// GET: SuperAdminLoginsController/Details/5
            //public ActionResult Details(int id)
            //{
            //    return View();
            //}

            //// GET: SuperAdminLoginsController/Create
            //public ActionResult Create()
            //{
            //    return View();
            //}

            //// POST: SuperAdminLoginsController/Create
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public ActionResult Create(IFormCollection collection)
            //{
            //    try
            //    {
            //        return RedirectToAction(nameof(Index));
            //    }
            //    catch
            //    {
            //        return View();
            //    }
            //}

            //// GET: SuperAdminLoginsController/Edit/5
            //public ActionResult Edit(int id)
            //{
            //    return View();
            //}

            //// POST: SuperAdminLoginsController/Edit/5
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public ActionResult Edit(int id, IFormCollection collection)
            //{
            //    try
            //    {
            //        return RedirectToAction(nameof(Index));
            //    }
            //    catch
            //    {
            //        return View();
            //    }
            //}

            //// GET: SuperAdminLoginsController/Delete/5
            //public ActionResult Delete(int id)
            //{
            //    return View();
            //}

            //// POST: SuperAdminLoginsController/Delete/5
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public ActionResult Delete(int id, IFormCollection collection)
            //{
            //    try
            //    {
            //        return RedirectToAction(nameof(Index));
            //    }
            //    catch
            //    {
            //        return View();
            //    }
            //}
        }
    }
}
