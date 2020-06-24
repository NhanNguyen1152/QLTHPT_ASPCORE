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
    public class NgachluongsController : Controller
    {
        private readonly acomptec_qlthptContext _context = new acomptec_qlthptContext();
        

        // GET: Ngachluongs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ngachluong.ToListAsync());
        }

        // GET: Ngachluongs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ngachluong = await _context.Ngachluong
                .FirstOrDefaultAsync(m => m.NlMa == id);
            if (ngachluong == null)
            {
                return NotFound();
            }

            return View(ngachluong);
        }

        // GET: Ngachluongs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ngachluongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NlMa,NlTen")] Ngachluong ngachluong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ngachluong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ngachluong);
        }

        // GET: Ngachluongs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ngachluong = await _context.Ngachluong.FindAsync(id);
            if (ngachluong == null)
            {
                return NotFound();
            }
            return View(ngachluong);
        }

        // POST: Ngachluongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NlMa,NlTen")] Ngachluong ngachluong)
        {
            if (id != ngachluong.NlMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ngachluong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NgachluongExists(ngachluong.NlMa))
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
            return View(ngachluong);
        }

        // GET: Ngachluongs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ngachluong = await _context.Ngachluong
                .FirstOrDefaultAsync(m => m.NlMa == id);
            if (ngachluong == null)
            {
                return NotFound();
            }

            return View(ngachluong);
        }

        // POST: Ngachluongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ngachluong = await _context.Ngachluong.FindAsync(id);
            _context.Ngachluong.Remove(ngachluong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NgachluongExists(string id)
        {
            return _context.Ngachluong.Any(e => e.NlMa == id);
        }
    }
}
