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
    public class AccountTypeFormatted
    {
        
    }

    public class AccountController : Controller
    {
        private readonly PlutoDbContext _context;

        public AccountController(PlutoDbContext context)
        {
            _context = context;
        }

        // GET: Account
        public async Task<IActionResult> Index()
        {
            var account = _context.Account
                .Include(u => u.User)
                .AsNoTracking();
            return View(await account.ToListAsync());
        }

        // GET: Account/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Account == null)
            {
                return NotFound();
            }

            var account = await _context.Account
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Account/Create
        public IActionResult Create()
        {
            PopulateAccountTypeDropDownList();
            PopulateUsersDropDownList();
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Number,AccountTypeId,UserId,Active,Note")] Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateUsersDropDownList(account.Id);
            PopulateAccountTypeDropDownList(account.AccountTypeId);
            return View(account);
        }

        // GET: Account/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Account == null)
            {
                return NotFound();
            }

            //var account = await _context.Account.FindAsync(id);
            var account = await _context.Account
                                        .Include(u => u.User)
                                        .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Account/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Number,AccountTypeId,OwnerUserId,Active,Note")] Account account)
        {
            if (id != account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.Id))
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
            return View(account);
        }

        // GET: Account/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Account == null)
            {
                return NotFound();
            }

            var account = await _context.Account
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Account == null)
            {
                return Problem("Entity set 'PlutoDbContext.Account'  is null.");
            }
            var account = await _context.Account.FindAsync(id);
            if (account != null)
            {
                _context.Account.Remove(account);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
          return _context.Account.Any(e => e.Id == id);
        }

        private void PopulateUsersDropDownList(object selectedUser = null)
        {
            var usersQuery = from d in _context.User
                                   orderby d.Surname
                                   select d;
            //ViewBag.UserId = new SelectList(usersQuery.AsNoTracking(), "Id", "Surname", selectedUser);
            ViewBag.UserId = new SelectList(_context.User.Select(
                c=> new
                {
                    Id = c.Id,
                    FullName = c.Surname + " " + c.Name
                }), "Id", "FullName", selectedUser);
        }

        private void PopulateAccountTypeDropDownList(object selectedType = null)
        {
            var enumData = from PlutoTool.Models.Account.AccountTypes e in Enum.GetValues(typeof(Account.AccountTypes))
                           select new
                           {
                               Id = (int)e,
                               //AccountType = e.ToString()
                               AccountType = Account.AccountTypesName[(int)e]
                           };
            ViewBag.AccountTypeId = new SelectList(enumData, "Id", "AccountType", selectedType);

            //ViewBag.AccountTypeId = new SelectList(_context.Account., "Id", "AccountType", selectedType);
        }
    }
}
