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
    public class PayeeController : Controller
    {
        private readonly PlutoDbContext _context;

        public PayeeController(PlutoDbContext context)
        {
            _context = context;
        }

        // GET: Payee
        public async Task<IActionResult> Index()
        {
              return View(await _context.Payee.ToListAsync());
        }

        // GET: Payee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Payee == null)
            {
                return NotFound();
            }

            var payee = await _context.Payee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payee == null)
            {
                return NotFound();
            }

            return View(payee);
        }

        // GET: Payee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Payee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PayeeTypeId,Email,Phone,Address,City,District,ZipCode,Country,NIN,VATID,Active,Note")] Payee payee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(payee);
        }

        // GET: Payee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Payee == null)
            {
                return NotFound();
            }

            var payee = await _context.Payee.FindAsync(id);
            if (payee == null)
            {
                return NotFound();
            }
            return View(payee);
        }

        // POST: Payee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PayeeTypeId,Email,Phone,Address,City,District,ZipCode,Country,NIN,VATID,Active,Note")] Payee payee)
        {
            if (id != payee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayeeExists(payee.Id))
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
            return View(payee);
        }

        // GET: Payee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Payee == null)
            {
                return NotFound();
            }

            var payee = await _context.Payee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payee == null)
            {
                return NotFound();
            }

            return View(payee);
        }

        // POST: Payee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Payee == null)
            {
                return Problem("Entity set 'PlutoDbContext.Payee'  is null.");
            }
            var payee = await _context.Payee.FindAsync(id);
            if (payee != null)
            {
                _context.Payee.Remove(payee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PayeeExists(int id)
        {
          return _context.Payee.Any(e => e.Id == id);
        }
    }
}
