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
    public class QuanhuyensController : Controller
    {
        private readonly acomptec_qlthptContext _context = new acomptec_qlthptContext();

        // GET: Quanhuyens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Quanhuyen.ToListAsync());
        }

        // GET: Quanhuyens/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanhuyen = await _context.Quanhuyen
                .FirstOrDefaultAsync(m => m.QhMa == id);
            if (quanhuyen == null)
            {
                return NotFound();
            }

            return View(quanhuyen);
        }

        // GET: Quanhuyens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quanhuyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QhMa,QhTen")] Quanhuyen quanhuyen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanhuyen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quanhuyen);
        }

        // GET: Quanhuyens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanhuyen = await _context.Quanhuyen.FindAsync(id);
            if (quanhuyen == null)
            {
                return NotFound();
            }
            return View(quanhuyen);
        }

        // POST: Quanhuyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("QhMa,QhTen")] Quanhuyen quanhuyen)
        {
            if (id != quanhuyen.QhMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanhuyen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanhuyenExists(quanhuyen.QhMa))
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
            return View(quanhuyen);
        }

        // GET: Quanhuyens/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanhuyen = await _context.Quanhuyen
                .FirstOrDefaultAsync(m => m.QhMa == id);
            if (quanhuyen == null)
            {
                return NotFound();
            }

            return View(quanhuyen);
        }

        // POST: Quanhuyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var quanhuyen = await _context.Quanhuyen.FindAsync(id);
            _context.Quanhuyen.Remove(quanhuyen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanhuyenExists(string id)
        {
            return _context.Quanhuyen.Any(e => e.QhMa == id);
        }
    }
}
