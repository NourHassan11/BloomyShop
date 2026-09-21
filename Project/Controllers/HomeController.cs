using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities.Data;
using Project.Models;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BloomyShopDbContext _context;

        public HomeController(ILogger<HomeController> logger, BloomyShopDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Pass up to 4 active bouquets as featured items for the home page
            var featured = await _context.Bouquets
                .Include(b => b.BouquetSize)
                .Where(b => b.IsActive)
                .Take(4)
                .AsNoTracking()
                .ToListAsync();

            ViewBag.FeaturedBouquets = featured;
            ViewData["Title"] = "Home";
            ViewData["Description"] = "Bloomy Shop — Premium botanical studio. Handcrafted bouquets, custom arrangements, and event floristry in Cairo.";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
