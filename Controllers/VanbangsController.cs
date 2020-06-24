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
    public class VanbangsController : Controller
    {
        private readonly acomptec_qlthptContext _context = new acomptec_qlthptContext();

        

        // GET: Vanbangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vanbang.ToListAsync());
        }

        // GET: Vanbangs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vanbang = await _context.Vanbang
                .FirstOrDefaultAsync(m => m.VbMa == id);
            if (vanbang == null)
            {
                return NotFound();
            }

            return View(vanbang);
        }

        // GET: Vanbangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vanbangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VbMa,VbTen")] Vanbang vanbang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vanbang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vanbang);
        }

        // GET: Vanbangs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vanbang = await _context.Vanbang.FindAsync(id);
            if (vanbang == null)
            {
                return NotFound();
            }
            return View(vanbang);
        }

        // POST: Vanbangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("VbMa,VbTen")] Vanbang vanbang)
        {
            if (id != vanbang.VbMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vanbang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VanbangExists(vanbang.VbMa))
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
            return View(vanbang);
        }

        // GET: Vanbangs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vanbang = await _context.Vanbang
                .FirstOrDefaultAsync(m => m.VbMa == id);
            if (vanbang == null)
            {
                return NotFound();
            }

            return View(vanbang);
        }

        // POST: Vanbangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vanbang = await _context.Vanbang.FindAsync(id);
            _context.Vanbang.Remove(vanbang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VanbangExists(string id)
        {
            return _context.Vanbang.Any(e => e.VbMa == id);
        }
    }
}
