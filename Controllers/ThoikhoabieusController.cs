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
    public class ThoikhoabieusController : Controller
    {
        private readonly acomptec_qlthptContext _context = new acomptec_qlthptContext();

        // GET: Thoikhoabieus
        public async Task<IActionResult> Index()
        {
            var acomptec_qlthptContext = _context.Thoikhoabieu.Include(t => t.CanboCbMaNavigation).Include(t => t.HockyHkMaNavigation).Include(t => t.LopLopMaNavigation).Include(t => t.MonhocMhMaNavigation).Include(t => t.ThuThuMaNavigation).Include(t => t.TiethocThMaNavigation);
            return View(await acomptec_qlthptContext.ToListAsync());
        }

        // GET: Thoikhoabieus/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thoikhoabieu = await _context.Thoikhoabieu
                .Include(t => t.CanboCbMaNavigation)
                .Include(t => t.HockyHkMaNavigation)
                .Include(t => t.LopLopMaNavigation)
                .Include(t => t.MonhocMhMaNavigation)
                .Include(t => t.ThuThuMaNavigation)
                .Include(t => t.TiethocThMaNavigation)
                .FirstOrDefaultAsync(m => m.TkbMa == id);
            if (thoikhoabieu == null)
            {
                return NotFound();
            }

            return View(thoikhoabieu);
        }

        // GET: Thoikhoabieus/Create
        public IActionResult Create()
        {
            ViewData["CanboCbMa"] = new SelectList(_context.Canbo, "CbMa", "CbMa");
            ViewData["HockyHkMa"] = new SelectList(_context.Hocky, "HkMa", "HkMa");
            ViewData["LopLopMa"] = new SelectList(_context.Lop, "LopMa", "LopMa");
            ViewData["MonhocMhMa"] = new SelectList(_context.Monhoc, "MhMa", "MhMa");
            ViewData["ThuThuMa"] = new SelectList(_context.Thu, "ThuMa", "ThuMa");
            ViewData["TiethocThMa"] = new SelectList(_context.Tiethoc, "ThMa", "ThMa");
            return View();
        }

        // POST: Thoikhoabieus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TkbMa,LopLopMa,MonhocMhMa,ThuThuMa,TiethocThMa,CanboCbMa,HockyHkMa")] Thoikhoabieu thoikhoabieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thoikhoabieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CanboCbMa"] = new SelectList(_context.Canbo, "CbMa", "CbMa", thoikhoabieu.CanboCbMa);
            ViewData["HockyHkMa"] = new SelectList(_context.Hocky, "HkMa", "HkMa", thoikhoabieu.HockyHkMa);
            ViewData["LopLopMa"] = new SelectList(_context.Lop, "LopMa", "LopMa", thoikhoabieu.LopLopMa);
            ViewData["MonhocMhMa"] = new SelectList(_context.Monhoc, "MhMa", "MhMa", thoikhoabieu.MonhocMhMa);
            ViewData["ThuThuMa"] = new SelectList(_context.Thu, "ThuMa", "ThuMa", thoikhoabieu.ThuThuMa);
            ViewData["TiethocThMa"] = new SelectList(_context.Tiethoc, "ThMa", "ThMa", thoikhoabieu.TiethocThMa);
            return View(thoikhoabieu);
        }

        // GET: Thoikhoabieus/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thoikhoabieu = await _context.Thoikhoabieu.FindAsync(id);
            if (thoikhoabieu == null)
            {
                return NotFound();
            }
            ViewData["CanboCbMa"] = new SelectList(_context.Canbo, "CbMa", "CbMa", thoikhoabieu.CanboCbMa);
            ViewData["HockyHkMa"] = new SelectList(_context.Hocky, "HkMa", "HkMa", thoikhoabieu.HockyHkMa);
            ViewData["LopLopMa"] = new SelectList(_context.Lop, "LopMa", "LopMa", thoikhoabieu.LopLopMa);
            ViewData["MonhocMhMa"] = new SelectList(_context.Monhoc, "MhMa", "MhMa", thoikhoabieu.MonhocMhMa);
            ViewData["ThuThuMa"] = new SelectList(_context.Thu, "ThuMa", "ThuMa", thoikhoabieu.ThuThuMa);
            ViewData["TiethocThMa"] = new SelectList(_context.Tiethoc, "ThMa", "ThMa", thoikhoabieu.TiethocThMa);
            return View(thoikhoabieu);
        }

        // POST: Thoikhoabieus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TkbMa,LopLopMa,MonhocMhMa,ThuThuMa,TiethocThMa,CanboCbMa,HockyHkMa")] Thoikhoabieu thoikhoabieu)
        {
            if (id != thoikhoabieu.TkbMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thoikhoabieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThoikhoabieuExists(thoikhoabieu.TkbMa))
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
            ViewData["CanboCbMa"] = new SelectList(_context.Canbo, "CbMa", "CbMa", thoikhoabieu.CanboCbMa);
            ViewData["HockyHkMa"] = new SelectList(_context.Hocky, "HkMa", "HkMa", thoikhoabieu.HockyHkMa);
            ViewData["LopLopMa"] = new SelectList(_context.Lop, "LopMa", "LopMa", thoikhoabieu.LopLopMa);
            ViewData["MonhocMhMa"] = new SelectList(_context.Monhoc, "MhMa", "MhMa", thoikhoabieu.MonhocMhMa);
            ViewData["ThuThuMa"] = new SelectList(_context.Thu, "ThuMa", "ThuMa", thoikhoabieu.ThuThuMa);
            ViewData["TiethocThMa"] = new SelectList(_context.Tiethoc, "ThMa", "ThMa", thoikhoabieu.TiethocThMa);
            return View(thoikhoabieu);
        }

        // GET: Thoikhoabieus/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thoikhoabieu = await _context.Thoikhoabieu
                .Include(t => t.CanboCbMaNavigation)
                .Include(t => t.HockyHkMaNavigation)
                .Include(t => t.LopLopMaNavigation)
                .Include(t => t.MonhocMhMaNavigation)
                .Include(t => t.ThuThuMaNavigation)
                .Include(t => t.TiethocThMaNavigation)
                .FirstOrDefaultAsync(m => m.TkbMa == id);
            if (thoikhoabieu == null)
            {
                return NotFound();
            }

            return View(thoikhoabieu);
        }

        // POST: Thoikhoabieus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var thoikhoabieu = await _context.Thoikhoabieu.FindAsync(id);
            _context.Thoikhoabieu.Remove(thoikhoabieu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThoikhoabieuExists(string id)
        {
            return _context.Thoikhoabieu.Any(e => e.TkbMa == id);
        }
    }
}
