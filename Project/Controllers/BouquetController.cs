using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using Project.DAL.Entities.Data;

namespace Project.Controllers
{
    public class BouquetController : Controller
    {
        private readonly BloomyShopDbContext _context;

        public BouquetController(BloomyShopDbContext context)
        {
            _context = context;
        }

        // GET: Bouquet
        public async Task<IActionResult> Index(string? searchString, int? sizeId)
        {
            var query = _context.Bouquets
                .Include(b => b.BouquetSize)
                .Include(b => b.BouquetFlowers)
                    .ThenInclude(bf => bf.Flower)
                .Where(b => b.IsActive)
                .AsQueryable();

            // Search by Bouquet Name or Flower Name
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(b =>
                    b.Name.Contains(searchString) ||
                    b.BouquetFlowers.Any(bf =>
                        bf.Flower.Name.Contains(searchString)));
            }

            // Filter by Size
            if (sizeId.HasValue)
            {
                query = query.Where(b => b.SizeID == sizeId.Value);
            }

            ViewBag.Sizes = await _context.BouquetSizes
                .AsNoTracking()
                .ToListAsync();

            ViewBag.SearchString = searchString;
            ViewBag.SelectedSize = sizeId;

            var bouquets = await query
                .AsNoTracking()
                .ToListAsync();

            return View(bouquets);
        }

        // GET: Bouquet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var bouquet = await _context.Bouquets
                .Include(b => b.BouquetSize)
                .Include(b => b.BouquetFlowers)
                    .ThenInclude(bf => bf.Flower)
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    b => b.BouquetID == id && b.IsActive);

            if (bouquet == null)
                return NotFound();

            return View(bouquet);
        }
    }
}