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
    public class MonhocsController : Controller
    {
        private readonly acomptec_qlthptContext _context = new acomptec_qlthptContext();

        // GET: Monhocs
        public async Task<IActionResult> Index()
        {
            var acomptec_qlthptContext = _context.Monhoc.Include(m => m.ChitietdanhgiaCtdgMaNavigation);
            return View(await acomptec_qlthptContext.ToListAsync());
        }

        // GET: Monhocs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monhoc = await _context.Monhoc
                .Include(m => m.ChitietdanhgiaCtdgMaNavigation)
                .FirstOrDefaultAsync(m => m.MhMa == id);
            if (monhoc == null)
            {
                return NotFound();
            }

            return View(monhoc);
        }

        // GET: Monhocs/Create
        public IActionResult Create()
        {
            ViewData["ChitietdanhgiaCtdgMa"] = new SelectList(_context.Chitietdanhgia, "CtdgMa", "CtdgMa");
            return View();
        }

        // POST: Monhocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MhMa,MhTen,ChitietdanhgiaCtdgMa")] Monhoc monhoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monhoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChitietdanhgiaCtdgMa"] = new SelectList(_context.Chitietdanhgia, "CtdgMa", "CtdgMa", monhoc.ChitietdanhgiaCtdgMa);
            return View(monhoc);
        }

        // GET: Monhocs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monhoc = await _context.Monhoc.FindAsync(id);
            if (monhoc == null)
            {
                return NotFound();
            }
            ViewData["ChitietdanhgiaCtdgMa"] = new SelectList(_context.Chitietdanhgia, "CtdgMa", "CtdgMa", monhoc.ChitietdanhgiaCtdgMa);
            return View(monhoc);
        }

        // POST: Monhocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MhMa,MhTen,ChitietdanhgiaCtdgMa")] Monhoc monhoc)
        {
            if (id != monhoc.MhMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monhoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonhocExists(monhoc.MhMa))
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
            ViewData["ChitietdanhgiaCtdgMa"] = new SelectList(_context.Chitietdanhgia, "CtdgMa", "CtdgMa", monhoc.ChitietdanhgiaCtdgMa);
            return View(monhoc);
        }

        // GET: Monhocs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monhoc = await _context.Monhoc
                .Include(m => m.ChitietdanhgiaCtdgMaNavigation)
                .FirstOrDefaultAsync(m => m.MhMa == id);
            if (monhoc == null)
            {
                return NotFound();
            }

            return View(monhoc);
        }

        // POST: Monhocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var monhoc = await _context.Monhoc.FindAsync(id);
            _context.Monhoc.Remove(monhoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonhocExists(string id)
        {
            return _context.Monhoc.Any(e => e.MhMa == id);
        }
    }
}
