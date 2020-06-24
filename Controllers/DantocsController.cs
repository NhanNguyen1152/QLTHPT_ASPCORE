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
    public class DantocsController : Controller
    {
       private readonly acomptec_qlthptContext _context = new acomptec_qlthptContext();


        // GET: Dantocs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dantoc.ToListAsync());
        }

        // GET: Dantocs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dantoc = await _context.Dantoc
                .FirstOrDefaultAsync(m => m.DtMa == id);
            if (dantoc == null)
            {
                return NotFound();
            }

            return View(dantoc);
        }

        // GET: Dantocs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dantocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DtMa,DtTen")] Dantoc dantoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dantoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dantoc);
        }

        // GET: Dantocs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dantoc = await _context.Dantoc.FindAsync(id);
            if (dantoc == null)
            {
                return NotFound();
            }
            return View(dantoc);
        }

        // POST: Dantocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DtMa,DtTen")] Dantoc dantoc)
        {
            if (id != dantoc.DtMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dantoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DantocExists(dantoc.DtMa))
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
            return View(dantoc);
        }

        // GET: Dantocs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dantoc = await _context.Dantoc
                .FirstOrDefaultAsync(m => m.DtMa == id);
            if (dantoc == null)
            {
                return NotFound();
            }

            return View(dantoc);
        }

        // POST: Dantocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dantoc = await _context.Dantoc.FindAsync(id);
            _context.Dantoc.Remove(dantoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DantocExists(string id)
        {
            return _context.Dantoc.Any(e => e.DtMa == id);
        }
    }
}
