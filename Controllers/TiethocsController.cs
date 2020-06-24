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
    public class TiethocsController : Controller
    {
        private readonly acomptec_qlthptContext _context = new acomptec_qlthptContext();


        // GET: Tiethocs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tiethoc.ToListAsync());
        }

        // GET: Tiethocs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiethoc = await _context.Tiethoc
                .FirstOrDefaultAsync(m => m.ThMa == id);
            if (tiethoc == null)
            {
                return NotFound();
            }

            return View(tiethoc);
        }

        // GET: Tiethocs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tiethocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ThMa,ThTen")] Tiethoc tiethoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiethoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiethoc);
        }

        // GET: Tiethocs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiethoc = await _context.Tiethoc.FindAsync(id);
            if (tiethoc == null)
            {
                return NotFound();
            }
            return View(tiethoc);
        }

        // POST: Tiethocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ThMa,ThTen")] Tiethoc tiethoc)
        {
            if (id != tiethoc.ThMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiethoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiethocExists(tiethoc.ThMa))
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
            return View(tiethoc);
        }

        // GET: Tiethocs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiethoc = await _context.Tiethoc
                .FirstOrDefaultAsync(m => m.ThMa == id);
            if (tiethoc == null)
            {
                return NotFound();
            }

            return View(tiethoc);
        }

        // POST: Tiethocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tiethoc = await _context.Tiethoc.FindAsync(id);
            _context.Tiethoc.Remove(tiethoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiethocExists(string id)
        {
            return _context.Tiethoc.Any(e => e.ThMa == id);
        }
    }
}
