using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using trangtin.Data;
using trangtin.Models;
using PagedList;


namespace trangtin.Controllers
{
    public class MainController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MainController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Main
        public async Task<IActionResult> Index()
        {
            // chuẩn bị danh sách chuyên mục
            var dschuyenmuc = await _context.chuyenmuc.ToListAsync();
            ViewBag.chuyenmuc = dschuyenmuc;
            var dschude = await _context.chude.ToListAsync();
            ViewBag.chude = dschude;


            // chuẩn bị dữ liệu bản tin
            var applicationDbContext = _context.bantin.Include(b => b.chude);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Main/Details/5
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

        
    }
}
