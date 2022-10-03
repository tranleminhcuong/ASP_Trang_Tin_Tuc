using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using trangtin.Data;
using trangtin.Models;

namespace trangtin.Controllers
{
    [Authorize]
    public class bantinController : Controller
    {
        private readonly ApplicationDbContext _context;

        public bantinController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: bantin
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.bantin.Include(b => b.chude);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: bantin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bantin = await _context.bantin
                .Include(b => b.chude)
                .FirstOrDefaultAsync(m => m.bantinid == id);
            if (bantin == null)
            {
                return NotFound();
            }

            return View(bantin);
        }

        // GET: bantin/Create
        public IActionResult Create()
        {
            ViewData["chudeid"] = new SelectList(_context.chude, "chudeid", "tenchude");
            return View();
        }

        // POST: bantin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("bantinid,chudeid,tieude,tomtat,noidung,ngaydang,nguoidang,hinhanh,tieudehinh,luotxem,noibat,kichhoat")] bantin bantin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bantin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["chudeid"] = new SelectList(_context.chude, "chudeid", "tenchude", bantin.chudeid);
            return View(bantin);
        }

        // GET: bantin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bantin = await _context.bantin.FindAsync(id);
            if (bantin == null)
            {
                return NotFound();
            }
            ViewData["chudeid"] = new SelectList(_context.chude, "chudeid", "tenchude", bantin.chudeid);
            return View(bantin);
        }

        // POST: bantin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("bantinid,chudeid,tieude,tomtat,noidung,ngaydang,nguoidang,hinhanh,tieudehinh,luotxem,noibat,kichhoat")] bantin bantin)
        {
            if (id != bantin.bantinid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bantin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!bantinExists(bantin.bantinid))
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
            ViewData["chudeid"] = new SelectList(_context.chude, "chudeid", "tenchude", bantin.chudeid);
            return View(bantin);
        }

        // GET: bantin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bantin = await _context.bantin
                .Include(b => b.chude)
                .FirstOrDefaultAsync(m => m.bantinid == id);
            if (bantin == null)
            {
                return NotFound();
            }

            return View(bantin);
        }

        // POST: bantin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bantin = await _context.bantin.FindAsync(id);
            _context.bantin.Remove(bantin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool bantinExists(int id)
        {
            return _context.bantin.Any(e => e.bantinid == id);
        }
    }
}
