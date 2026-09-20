using Microsoft.AspNetCore.Mvc;
using Project.DAL.Entities.Data;
using System.Linq;

namespace Project.Controllers
{
    public class EventRequestController : Controller
    {
        private readonly BloomyShopDbContext _context;

        public EventRequestController(BloomyShopDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var eventRequests = _context.EventRequests.ToList();

            return View(eventRequests);
        }
    }
}