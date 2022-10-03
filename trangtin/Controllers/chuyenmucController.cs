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
    public class chuyenmucController : Controller
    {
        private readonly ApplicationDbContext _context;

        public chuyenmucController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: chuyenmuc
        public async Task<IActionResult> Index()
        {
            return View(await _context.chuyenmuc.ToListAsync());
        }

        // GET: chuyenmuc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chuyenmuc = await _context.chuyenmuc
                .FirstOrDefaultAsync(m => m.chuyenmucid == id);
            if (chuyenmuc == null)
            {
                return NotFound();
            }

            return View(chuyenmuc);
        }

        // GET: chuyenmuc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: chuyenmuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("chuyenmucid,tenchuyenmuc,thutu")] chuyenmuc chuyenmuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chuyenmuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chuyenmuc);
        }

        // GET: chuyenmuc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chuyenmuc = await _context.chuyenmuc.FindAsync(id);
            if (chuyenmuc == null)
            {
                return NotFound();
            }
            return View(chuyenmuc);
        }

        // POST: chuyenmuc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("chuyenmucid,tenchuyenmuc,thutu")] chuyenmuc chuyenmuc)
        {
            if (id != chuyenmuc.chuyenmucid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chuyenmuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!chuyenmucExists(chuyenmuc.chuyenmucid))
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
            return View(chuyenmuc);
        }

        // GET: chuyenmuc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chuyenmuc = await _context.chuyenmuc
                .FirstOrDefaultAsync(m => m.chuyenmucid == id);
            if (chuyenmuc == null)
            {
                return NotFound();
            }

            return View(chuyenmuc);
        }

        // POST: chuyenmuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chuyenmuc = await _context.chuyenmuc.FindAsync(id);
            _context.chuyenmuc.Remove(chuyenmuc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool chuyenmucExists(int id)
        {
            return _context.chuyenmuc.Any(e => e.chuyenmucid == id);
        }
    }
}
