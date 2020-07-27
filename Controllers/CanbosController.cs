using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTHPT.Models;

namespace QLTHPT.Controllers {
    public class CanbosController : Controller {
        private readonly acomptec_qlthptContext _context = new acomptec_qlthptContext();

        // GET: Canbos
        public async Task<IActionResult> Index () {
            var acomptec_qlthptContext = _context.Canbo.Include (c => c.CoquanCqMaNavigation).Include (c => c.KhenthuongcbKtcbMaNavigation).Include (c => c.KyluatcbKlcbMaNavigation);
            return View (await acomptec_qlthptContext.ToListAsync ());
        }

        // GET: Canbos/Details/5
        public async Task<IActionResult> Details (string id) {
            if (id == null) {
                return NotFound ();
            }

            var canbo = await _context.Canbo
                .Include (c => c.CoquanCqMaNavigation)
                .Include (c => c.KhenthuongcbKtcbMaNavigation)
                .Include (c => c.KyluatcbKlcbMaNavigation)
                .FirstOrDefaultAsync (m => m.CbMa == id);
            if (canbo == null) {
                return NotFound ();
            }

            return View (canbo);
        }

        public async Task<IActionResult> Print (string id) {
            if (id == null) {
                return NotFound ();
            }

            var canbo = await _context.Canbo
                .FirstOrDefaultAsync (m => m.CbMa == id);
            if (canbo == null) {
                return NotFound ();
            }

            return View (canbo);
        }

        // GET: Canbos/Create
        public IActionResult Create () {
            ViewData["CoquanCqMa"] = new SelectList (_context.Coquan, "CqMa", "CqMa");
            ViewData["KhenthuongcbKtcbMa"] = new SelectList (_context.Khenthuongcb, "KtcbMa", "KtcbMa");
            ViewData["KyluatcbKlcbMa"] = new SelectList (_context.Kyluatcb, "KlcbMa", "KlcbMa");
            return View();
        }

        // POST: Canbos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("CbMa,CbHoten,CbGioitinh,CbDiachi,CbNgaysinh,CbCmnd,CoquanCqMa,KyluatcbKlcbMa,KhenthuongcbKtcbMa")] Canbo canbo) {
            if (ModelState.IsValid) {
                _context.Add (canbo);
                await _context.SaveChangesAsync ();
                return RedirectToAction (nameof (Index));
            }
            ViewData["CoquanCqMa"] = new SelectList (_context.Coquan, "CqMa", "CqMa", canbo.CoquanCqMa);
            ViewData["KhenthuongcbKtcbMa"] = new SelectList (_context.Khenthuongcb, "KtcbMa", "KtcbMa", canbo.KhenthuongcbKtcbMa);
            ViewData["KyluatcbKlcbMa"] = new SelectList (_context.Kyluatcb, "KlcbMa", "KlcbMa", canbo.KyluatcbKlcbMa);
            return View (canbo);
        }

        // GET: Canbos/Edit/5
        public async Task<IActionResult> Edit (string id) {
            if (id == null) {
                return NotFound ();
            }

            var canbo = await _context.Canbo.FindAsync (id);
            if (canbo == null) {
                return NotFound ();
            }
            ViewData["CoquanCqMa"] = new SelectList (_context.Coquan, "CqMa", "CqMa", canbo.CoquanCqMa);
            ViewData["KhenthuongcbKtcbMa"] = new SelectList (_context.Khenthuongcb, "KtcbMa", "KtcbMa", canbo.KhenthuongcbKtcbMa);
            ViewData["KyluatcbKlcbMa"] = new SelectList (_context.Kyluatcb, "KlcbMa", "KlcbMa", canbo.KyluatcbKlcbMa);
            return View (canbo);
        }

        // POST: Canbos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (string id, [Bind ("CbMa,CbHoten,CbGioitinh,CbDiachi,CbNgaysinh,CbCmnd,CoquanCqMa,KyluatcbKlcbMa,KhenthuongcbKtcbMa")] Canbo canbo) {
            if (id != canbo.CbMa) {
                return NotFound ();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update (canbo);
                    await _context.SaveChangesAsync ();
                } catch (DbUpdateConcurrencyException) {
                    if (!CanboExists (canbo.CbMa)) {
                        return NotFound ();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction (nameof (Index));
            }
            ViewData["CoquanCqMa"] = new SelectList (_context.Coquan, "CqMa", "CqMa", canbo.CoquanCqMa);
            ViewData["KhenthuongcbKtcbMa"] = new SelectList (_context.Khenthuongcb, "KtcbMa", "KtcbMa", canbo.KhenthuongcbKtcbMa);
            ViewData["KyluatcbKlcbMa"] = new SelectList (_context.Kyluatcb, "KlcbMa", "KlcbMa", canbo.KyluatcbKlcbMa);
            return View (canbo);
        }

        // GET: Canbos/Delete/5
        public async Task<IActionResult> Delete (string id) {
            if (id == null) {
                return NotFound ();
            }

            var canbo = await _context.Canbo
                .Include (c => c.CoquanCqMaNavigation)
                .Include (c => c.KhenthuongcbKtcbMaNavigation)
                .Include (c => c.KyluatcbKlcbMaNavigation)
                .FirstOrDefaultAsync (m => m.CbMa == id);
            if (canbo == null) {
                return NotFound ();
            }

            return View (canbo);
        }

        // POST: Canbos/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (string id) {
            var canbo = await _context.Canbo.FindAsync (id);
            _context.Canbo.Remove (canbo);
            await _context.SaveChangesAsync ();
            return RedirectToAction (nameof (Index));
        }

        private bool CanboExists (string id) {
            return _context.Canbo.Any (e => e.CbMa == id);
        }
    }
}