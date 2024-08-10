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
    public class VehicleRouteTablesController : Controller
    {
        private readonly LogisticContext _context;

        public VehicleRouteTablesController(LogisticContext context)
        {
            _context = context;
        }

        // GET: VehicleRouteTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleRouteTables.ToListAsync());
        }

        // GET: VehicleRouteTables/Details/5
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var vehicleRouteTable = await _context.VehicleRouteTables
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (vehicleRouteTable == null)
            {
                return NotFound();
            }

            return View(vehicleRouteTable);
           
        }

        // GET: VehicleRouteTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleRouteTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DriverName,DateOfBirth,Address,PhoneNo,LicenseNumber,LicenseDate,LicenseExpiryDate,VehicleModel,VehicleNumber,DistanceTravelByVehicle,Source,Destination,CreatedAt,CreatedBy,ModifiedAt,ModifiedBy,DummyColumn1,DummyColumn2")] VehicleRouteTable vehicleRouteTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleRouteTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleRouteTable);
            //return RedirectToAction(nameof(Edit));
        }

        // GET: VehicleRouteTables/Edit/5
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var vehicleRouteTable = await _context.VehicleRouteTables.FindAsync(Id);
            if (vehicleRouteTable == null)
            {
                return NotFound();
            }
            return View(vehicleRouteTable);
        }

        // POST: VehicleRouteTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("Id,DriverName,DateOfBirth,Address,PhoneNo,LicenseNumber,LicenseDate,LicenseExpiryDate,VehicleModel,VehicleNumber,DistanceTravelByVehicle,Source,Destination,CreatedAt,CreatedBy,ModifiedAt,ModifiedBy,DummyColumn1,DummyColumn2")] VehicleRouteTable vehicleRouteTable)
        {
            if (Id != vehicleRouteTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleRouteTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleRouteTableExists(vehicleRouteTable.Id))
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
            return View(vehicleRouteTable);
        }

        // GET: VehicleRouteTables/Delete/5
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var vehicleRouteTable = await _context.VehicleRouteTables
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (vehicleRouteTable == null)
            {
                return NotFound();
            }

            return View(vehicleRouteTable);
        }

        // POST: VehicleRouteTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var vehicleRouteTable = await _context.VehicleRouteTables.FindAsync(Id);
            if (vehicleRouteTable != null)
            {
                _context.VehicleRouteTables.Remove(vehicleRouteTable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleRouteTableExists(int Id)
        {
            return _context.VehicleRouteTables.Any(e => e.Id == Id);
        }
    }
}
