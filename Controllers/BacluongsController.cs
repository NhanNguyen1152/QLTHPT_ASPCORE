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
    public class BacluongsController : Controller
    {

       private readonly acomptec_qlthptContext _context = new acomptec_qlthptContext();

        // GET: Bacluongs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bacluong.ToListAsync());
        }

        // GET: Bacluongs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bacluong = await _context.Bacluong
                .FirstOrDefaultAsync(m => m.BlMa == id);
            if (bacluong == null)
            {
                return NotFound();
            }

            return View(bacluong);
        }

        // GET: Bacluongs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bacluongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BlMa,BlTen")] Bacluong bacluong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bacluong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bacluong);
        }

        // GET: Bacluongs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bacluong = await _context.Bacluong.FindAsync(id);
            if (bacluong == null)
            {
                return NotFound();
            }
            return View(bacluong);
        }

        // POST: Bacluongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BlMa,BlTen")] Bacluong bacluong)
        {
            if (id != bacluong.BlMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bacluong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BacluongExists(bacluong.BlMa))
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
            return View(bacluong);
        }

        // GET: Bacluongs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bacluong = await _context.Bacluong
                .FirstOrDefaultAsync(m => m.BlMa == id);
            if (bacluong == null)
            {
                return NotFound();
            }

            return View(bacluong);
        }

        // POST: Bacluongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var bacluong = await _context.Bacluong.FindAsync(id);
            _context.Bacluong.Remove(bacluong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BacluongExists(string id)
        {
            return _context.Bacluong.Any(e => e.BlMa == id);
        }
    }
}
