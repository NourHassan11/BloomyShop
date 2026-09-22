using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using Project.DAL.Entities.Data;

namespace Project.Controllers
{
    public class AdminBouquetController : Controller
    {
        private readonly BloomyShopDbContext _context;

        public AdminBouquetController(BloomyShopDbContext context)
        {
            _context = context;
        }

        // GET: AdminBouquet
        public async Task<IActionResult> Index()
        {
            var bouquets = await _context.Bouquets
                .Include(b => b.BouquetSize)
                .Include(b => b.BouquetFlowers)
                    .ThenInclude(bf => bf.Flower)
                .AsNoTracking()
                .ToListAsync();

            return View(bouquets);
        }
        // GET: AdminBouquet/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Sizes = await _context.BouquetSizes.ToListAsync();

            return View();
        }

        // POST: AdminBouquet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bouquet bouquet)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Sizes = await _context.BouquetSizes.ToListAsync();
                return View(bouquet);
            }

            _context.Bouquets.Add(bouquet);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        // GET: AdminBouquet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var bouquet = await _context.Bouquets.FindAsync(id);

            if (bouquet == null)
                return NotFound();

            ViewBag.Sizes = await _context.BouquetSizes.ToListAsync();

            return View(bouquet);
        }

        // POST: AdminBouquet/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Bouquet bouquet)
        {
            if (id != bouquet.BouquetID)
                return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.Sizes = await _context.BouquetSizes.ToListAsync();
                return View(bouquet);
            }

            _context.Bouquets.Update(bouquet);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // GET: AdminBouquet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var bouquet = await _context.Bouquets
                .Include(b => b.BouquetSize)
                .FirstOrDefaultAsync(b => b.BouquetID == id);

            if (bouquet == null)
                return NotFound();

            return View(bouquet);
        }

        // POST: AdminBouquet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bouquet = await _context.Bouquets.FindAsync(id);

            if (bouquet != null)
            {
                _context.Bouquets.Remove(bouquet);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}