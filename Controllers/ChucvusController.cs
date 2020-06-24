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
    public class ChucvusController : Controller
    {
        private readonly acomptec_qlthptContext _context = new acomptec_qlthptContext();


   // GET: Chucvus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chucvu.ToListAsync());
        }

        // GET: Chucvus/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chucvu = await _context.Chucvu
                .FirstOrDefaultAsync(m => m.CvMa == id);
            if (chucvu == null)
            {
                return NotFound();
            }

            return View(chucvu);
        }

        // GET: Chucvus/Create
       public IActionResult Create()
        {
            return View();
        }

        // POST: Chucvus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CvMa,CvTen")] Chucvu chucvu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chucvu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chucvu);
        }

        // GET: Chucvus/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chucvu = await _context.Chucvu.FindAsync(id);
            if (chucvu == null)
            {
                return NotFound();
            }
            return View(chucvu);
        }

        // POST: Chucvus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CvMa,CvTen")] Chucvu chucvu)
        {
            if (id != chucvu.CvMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chucvu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChucvuExists(chucvu.CvMa))
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
            return View(chucvu);
        }

        // GET: Chucvus/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chucvu = await _context.Chucvu
                .FirstOrDefaultAsync(m => m.CvMa == id);
            if (chucvu == null)
            {
                return NotFound();
            }

            return View(chucvu);
        }

        // POST: Chucvus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var chucvu = await _context.Chucvu.FindAsync(id);
            _context.Chucvu.Remove(chucvu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChucvuExists(string id)
        {
            return _context.Chucvu.Any(e => e.CvMa == id);
        }
    }
}
