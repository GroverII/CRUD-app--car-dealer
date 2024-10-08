using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD.Data;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class CarsController : Controller
    {
        private readonly CRUDContext _context;

        public CarsController(CRUDContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var car = await _context.Car
                .Include(x => x.Brand)
                .Include(x => x.FuelType)
                .AsNoTracking()
                .ToListAsync();

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            var brand =  _context.Brand
                .ToList();
            if (brand != null)
            {
                ViewData["brandNames"] = brand;
            }

            var fuelType =  _context.FuelType
                .ToList();
            if (fuelType != null)
            {
                ViewData["fuelTypeNames"] = fuelType;
            }
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BrandId,FuelTypeId,Model,Color,Mileage,ManufacturingDate,Price")] Car car)
        {
            if (car.Model != null && car.Color != null)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(x => x.Brand)
                .Include(x => x.FuelType)
                .FirstOrDefaultAsync(i => i.Id == id.Value);
            
            var brand = await _context.Brand
                .ToListAsync();
            if (brand != null)
            {
                ViewData["brandNames"] = brand;
            }
           
            var fuelType = await _context.FuelType
                .ToListAsync();
            if (fuelType != null)
            {
                ViewData["fuelTypeNames"] = fuelType;
            }

            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BrandId,FuelTypeId,Model,Color,Mileage,ManufacturingDate,Price")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (car.Model != null && car.Color != null)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(x => x.Brand)
                .Include(x => x.FuelType)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Car.FindAsync(id);
            if (car != null)
            {
                _context.Car.Remove(car);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.Id == id);
        }
    }
}
