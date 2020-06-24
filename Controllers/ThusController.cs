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
    public class ThusController : Controller
    {
        private readonly acomptec_qlthptContext _context = new acomptec_qlthptContext();

        // GET: Thus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Thu.ToListAsync());
        }

        // GET: Thus/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thu = await _context.Thu
                .FirstOrDefaultAsync(m => m.ThuMa == id);
            if (thu == null)
            {
                return NotFound();
            }

            return View(thu);
        }

        // GET: Thus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Thus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ThuMa,ThuTen")] Thu thu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thu);
        }

        // GET: Thus/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thu = await _context.Thu.FindAsync(id);
            if (thu == null)
            {
                return NotFound();
            }
            return View(thu);
        }

        // POST: Thus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ThuMa,ThuTen")] Thu thu)
        {
            if (id != thu.ThuMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThuExists(thu.ThuMa))
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
            return View(thu);
        }

        // GET: Thus/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thu = await _context.Thu
                .FirstOrDefaultAsync(m => m.ThuMa == id);
            if (thu == null)
            {
                return NotFound();
            }

            return View(thu);
        }

        // POST: Thus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var thu = await _context.Thu.FindAsync(id);
            _context.Thu.Remove(thu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThuExists(string id)
        {
            return _context.Thu.Any(e => e.ThuMa == id);
        }
    }
}
