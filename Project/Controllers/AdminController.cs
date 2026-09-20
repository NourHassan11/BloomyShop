using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using Project.DAL.Entities.Data;

namespace Project.Controllers
{
    public class AdminController : Controller
    {
        private readonly BloomyShopDbContext _context;

        public AdminController(BloomyShopDbContext context)
        {
            _context = context;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            var admins = await _context.Admins
                .AsNoTracking()
                .ToListAsync();

            return View(admins);
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var admin = await _context.Admins
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.AdminID == id);

            if (admin == null)
                return NotFound();

            return View(admin);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                _context.Admins.Add(admin);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(admin);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var admin = await _context.Admins.FindAsync(id);

            if (admin == null)
                return NotFound();

            return View(admin);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Admin admin)
        {
            if (id != admin.AdminID)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Admins.Update(admin);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(admin);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var admin = await _context.Admins
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.AdminID == id);

            if (admin == null)
                return NotFound();

            return View(admin);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admin = await _context.Admins.FindAsync(id);

            if (admin != null)
            {
                _context.Admins.Remove(admin);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/EventRequests
        public async Task<IActionResult> EventRequests()
        {
            var eventRequests = await _context.EventRequests
                .Include(e => e.Customer)
                .Include(e => e.Occasion)
                .Include(e => e.Admin)
                .AsNoTracking()
                .ToListAsync();

            return View(eventRequests);
        }

        // GET: Admin/ReviewEventRequest/5
        public async Task<IActionResult> ReviewEventRequest(int? id)
        {
            if (id == null)
                return NotFound();

            var eventRequest = await _context.EventRequests
                .Include(e => e.Customer)
                .Include(e => e.Occasion)
                .FirstOrDefaultAsync(e => e.EventRequestID == id);

            if (eventRequest == null)
                return NotFound();

            return View(eventRequest);
        }

        // POST: Admin/ReviewEventRequest
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReviewEventRequest(
            int EventRequestID,
            int AdminID,
            string? AdminResponse)
        {
            var eventRequest = await _context.EventRequests
                .FirstOrDefaultAsync(e => e.EventRequestID == EventRequestID);

            if (eventRequest == null)
                return NotFound();

            eventRequest.AdminID = AdminID;
            eventRequest.AdminResponse = AdminResponse;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(EventRequests));
        }
    }
}
