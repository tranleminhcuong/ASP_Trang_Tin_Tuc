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
    public class chudeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public chudeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: chude
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.chude.Include(c => c.chuyenmuc);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: chude/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chude = await _context.chude
                .Include(c => c.chuyenmuc)
                .FirstOrDefaultAsync(m => m.chudeid == id);
            if (chude == null)
            {
                return NotFound();
            }

            return View(chude);
        }

        // GET: chude/Create
        public IActionResult Create()
        {
            ViewData["chuyenmucid"] = new SelectList(_context.chuyenmuc, "chuyenmucid", "tenchuyenmuc");
            return View();
        }

        // POST: chude/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("chudeid,tenchude,chuyenmucid,thutu,kichhoat")] chude chude)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chude);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["chuyenmucid"] = new SelectList(_context.chuyenmuc, "chuyenmucid", "tenchuyenmuc", chude.chuyenmucid);
            return View(chude);
        }

        // GET: chude/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chude = await _context.chude.FindAsync(id);
            if (chude == null)
            {
                return NotFound();
            }
            ViewData["chuyenmucid"] = new SelectList(_context.chuyenmuc, "chuyenmucid", "tenchuyenmuc", chude.chuyenmucid);
            return View(chude);
        }

        // POST: chude/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("chudeid,tenchude,chuyenmucid,thutu,kichhoat")] chude chude)
        {
            if (id != chude.chudeid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chude);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!chudeExists(chude.chudeid))
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
            ViewData["chuyenmucid"] = new SelectList(_context.chuyenmuc, "chuyenmucid", "tenchuyenmuc", chude.chuyenmucid);
            return View(chude);
        }

        // GET: chude/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chude = await _context.chude
                .Include(c => c.chuyenmuc)
                .FirstOrDefaultAsync(m => m.chudeid == id);
            if (chude == null)
            {
                return NotFound();
            }

            return View(chude);
        }

        // POST: chude/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chude = await _context.chude.FindAsync(id);
            _context.chude.Remove(chude);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool chudeExists(int id)
        {
            return _context.chude.Any(e => e.chudeid == id);
        }
    }
}
