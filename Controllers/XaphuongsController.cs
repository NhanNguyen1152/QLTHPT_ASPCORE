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
    public class XaphuongsController : Controller
    {
        private readonly acomptec_qlthptContext _context = new acomptec_qlthptContext();

        // GET: Xaphuongs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Xaphuong.ToListAsync());
        }

        // GET: Xaphuongs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xaphuong = await _context.Xaphuong
                .FirstOrDefaultAsync(m => m.XpMa == id);
            if (xaphuong == null)
            {
                return NotFound();
            }

            return View(xaphuong);
        }

        // GET: Xaphuongs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Xaphuongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("XpMa,XpTen")] Xaphuong xaphuong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(xaphuong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(xaphuong);
        }

        // GET: Xaphuongs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xaphuong = await _context.Xaphuong.FindAsync(id);
            if (xaphuong == null)
            {
                return NotFound();
            }
            return View(xaphuong);
        }

        // POST: Xaphuongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("XpMa,XpTen")] Xaphuong xaphuong)
        {
            if (id != xaphuong.XpMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(xaphuong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!XaphuongExists(xaphuong.XpMa))
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
            return View(xaphuong);
        }

        // GET: Xaphuongs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xaphuong = await _context.Xaphuong
                .FirstOrDefaultAsync(m => m.XpMa == id);
            if (xaphuong == null)
            {
                return NotFound();
            }

            return View(xaphuong);
        }

        // POST: Xaphuongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var xaphuong = await _context.Xaphuong.FindAsync(id);
            _context.Xaphuong.Remove(xaphuong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool XaphuongExists(string id)
        {
            return _context.Xaphuong.Any(e => e.XpMa == id);
        }
    }
}
