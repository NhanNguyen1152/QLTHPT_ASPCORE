using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTHPT.Models;

namespace QLTHPT.Controllers
{
    public class NamhocsController : Controller
    {
        private readonly acomptec_qlthptContext _context = new acomptec_qlthptContext();

        // GET: Namhocs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Namhoc.ToListAsync());
        }

        // GET: Namhocs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var namhoc = await _context.Namhoc
                .FirstOrDefaultAsync(m => m.NhMa == id);
            if (namhoc == null)
            {
                return NotFound();
            }

            return View(namhoc);
        }

        // GET: Namhocs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Namhocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NhMa,NhNamhoc")] Namhoc namhoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(namhoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(namhoc);
        }

        // GET: Namhocs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var namhoc = await _context.Namhoc.FindAsync(id);
            if (namhoc == null)
            {
                return NotFound();
            }
            return View(namhoc);
        }

        // POST: Namhocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NhMa,NhNamhoc")] Namhoc namhoc)
        {
            if (id != namhoc.NhMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(namhoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NamhocExists(namhoc.NhMa))
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
            return View(namhoc);
        }

        // GET: Namhocs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var namhoc = await _context.Namhoc
                .FirstOrDefaultAsync(m => m.NhMa == id);
            if (namhoc == null)
            {
                return NotFound();
            }

            return View(namhoc);
        }

        // POST: Namhocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var namhoc = await _context.Namhoc.FindAsync(id);
            _context.Namhoc.Remove(namhoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NamhocExists(string id)
        {
            return _context.Namhoc.Any(e => e.NhMa == id);
        }
    }
}
