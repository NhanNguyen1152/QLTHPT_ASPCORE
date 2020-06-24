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
    public class HockysController : Controller
    {
        private readonly acomptec_qlthptContext _context = new acomptec_qlthptContext();        

        // GET: Hockys
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hocky.ToListAsync());
        }

        // GET: Hockys/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocky = await _context.Hocky
                .FirstOrDefaultAsync(m => m.HkMa == id);
            if (hocky == null)
            {
                return NotFound();
            }

            return View(hocky);
        }

        // GET: Hockys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hockys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HkMa,HkTen")] Hocky hocky)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hocky);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hocky);
        }

        // GET: Hockys/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocky = await _context.Hocky.FindAsync(id);
            if (hocky == null)
            {
                return NotFound();
            }
            return View(hocky);
        }

        // POST: Hockys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("HkMa,HkTen")] Hocky hocky)
        {
            if (id != hocky.HkMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hocky);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HockyExists(hocky.HkMa))
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
            return View(hocky);
        }

        // GET: Hockys/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocky = await _context.Hocky
                .FirstOrDefaultAsync(m => m.HkMa == id);
            if (hocky == null)
            {
                return NotFound();
            }

            return View(hocky);
        }

        // POST: Hockys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hocky = await _context.Hocky.FindAsync(id);
            _context.Hocky.Remove(hocky);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HockyExists(string id)
        {
            return _context.Hocky.Any(e => e.HkMa == id);
        }
    }
}
