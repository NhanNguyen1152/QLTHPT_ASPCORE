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
    public class CoquansController : Controller
    {
        private readonly acomptec_qlthptContext _context = new acomptec_qlthptContext();

        // GET: Coquans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coquan.ToListAsync());
        }

        // GET: Coquans/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coquan = await _context.Coquan
                .FirstOrDefaultAsync(m => m.CqMa == id);
            if (coquan == null)
            {
                return NotFound();
            }

            return View(coquan);
        }

        // GET: Coquans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coquans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CqMa,CqTen")] Coquan coquan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coquan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coquan);
        }

        // GET: Coquans/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coquan = await _context.Coquan.FindAsync(id);
            if (coquan == null)
            {
                return NotFound();
            }
            return View(coquan);
        }

        // POST: Coquans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CqMa,CqTen")] Coquan coquan)
        {
            if (id != coquan.CqMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coquan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoquanExists(coquan.CqMa))
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
            return View(coquan);
        }

        // GET: Coquans/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coquan = await _context.Coquan
                .FirstOrDefaultAsync(m => m.CqMa == id);
            if (coquan == null)
            {
                return NotFound();
            }

            return View(coquan);
        }

        // POST: Coquans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var coquan = await _context.Coquan.FindAsync(id);
            _context.Coquan.Remove(coquan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoquanExists(string id)
        {
            return _context.Coquan.Any(e => e.CqMa == id);
        }
    }
}
