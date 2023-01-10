using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlutoTool.Database;
using PlutoTool.Models;

namespace PlutoTool.Controllers
{
    public class WorkOrderController : Controller
    {
        private readonly PlutoDbContext _context;

        public WorkOrderController(PlutoDbContext context)
        {
            _context = context;
        }

        // GET: WorkOrder
        public async Task<IActionResult> Index()
        {
              return View(await _context.WorkOrder.ToListAsync());
        }

        // GET: WorkOrder/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WorkOrder == null)
            {
                return NotFound();
            }

            var workOrder = await _context.WorkOrder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workOrder == null)
            {
                return NotFound();
            }

            return View(workOrder);
        }

        // GET: WorkOrder/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkOrder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,StartDate,EndDate,Note")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workOrder);
        }

        // GET: WorkOrder/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WorkOrder == null)
            {
                return NotFound();
            }

            var workOrder = await _context.WorkOrder.FindAsync(id);
            if (workOrder == null)
            {
                return NotFound();
            }
            return View(workOrder);
        }

        // POST: WorkOrder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,StartDate,EndDate,Note")] WorkOrder workOrder)
        {
            if (id != workOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOrderExists(workOrder.Id))
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
            return View(workOrder);
        }

        // GET: WorkOrder/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WorkOrder == null)
            {
                return NotFound();
            }

            var workOrder = await _context.WorkOrder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workOrder == null)
            {
                return NotFound();
            }

            return View(workOrder);
        }

        // POST: WorkOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WorkOrder == null)
            {
                return Problem("Entity set 'PlutoDbContext.WorkOrder'  is null.");
            }
            var workOrder = await _context.WorkOrder.FindAsync(id);
            if (workOrder != null)
            {
                _context.WorkOrder.Remove(workOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkOrderExists(int id)
        {
          return _context.WorkOrder.Any(e => e.Id == id);
        }
    }
}
