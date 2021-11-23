using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using salesProject.Models;

namespace salesProject.Controllers
{
    public class SalesRecordController : Controller
    {
        private readonly SaleDbContext _context;

        public SalesRecordController(SaleDbContext context)
        {
            _context = context;
        }

        // GET: SalesRecord
        public async Task<IActionResult> Index()
        {
            var saleDbContext = _context.SalesRecord.Include(s => s.Seller);
            return View(await saleDbContext.ToListAsync());
        }

        // GET: SalesRecord/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesRecord = await _context.SalesRecord
                .Include(s => s.Seller)
                .FirstOrDefaultAsync(m => m.SalesRecordId == id);
            if (salesRecord == null)
            {
                return NotFound();
            }

            return View(salesRecord);
        }

        // GET: SalesRecord/Create
        public IActionResult Create()
        {
            ViewData["SellerId"] = new SelectList(_context.Seller, "SellerId", "SellerId");
            return View();
        }

        // POST: SalesRecord/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesRecordId,Date,Amount,status,SellerId")] SalesRecord salesRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SellerId"] = new SelectList(_context.Seller, "SellerId", "SellerId", salesRecord.SellerId);
            return View(salesRecord);
        }

        // GET: SalesRecord/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesRecord = await _context.SalesRecord.FindAsync(id);
            if (salesRecord == null)
            {
                return NotFound();
            }
            ViewData["SellerId"] = new SelectList(_context.Seller, "SellerId", "SellerId", salesRecord.SellerId);
            return View(salesRecord);
        }

        // POST: SalesRecord/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesRecordId,Date,Amount,status,SellerId")] SalesRecord salesRecord)
        {
            if (id != salesRecord.SalesRecordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesRecordExists(salesRecord.SalesRecordId))
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
            ViewData["SellerId"] = new SelectList(_context.Seller, "SellerId", "SellerId", salesRecord.SellerId);
            return View(salesRecord);
        }

        // GET: SalesRecord/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesRecord = await _context.SalesRecord
                .Include(s => s.Seller)
                .FirstOrDefaultAsync(m => m.SalesRecordId == id);
            if (salesRecord == null)
            {
                return NotFound();
            }

            return View(salesRecord);
        }

        // POST: SalesRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesRecord = await _context.SalesRecord.FindAsync(id);
            _context.SalesRecord.Remove(salesRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesRecordExists(int id)
        {
            return _context.SalesRecord.Any(e => e.SalesRecordId == id);
        }
    }
}
