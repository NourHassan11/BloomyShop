using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.DAL.Entities;

namespace Project.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            var admins = await _adminService.GetAllAsync();

            return View(admins);
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var admin = await _adminService.GetByIdAsync(id.Value);

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
                await _adminService.AddAsync(admin);

                return RedirectToAction(nameof(Index));
            }

            return View(admin);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var admin = await _adminService.GetByIdAsync(id.Value);

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
                await _adminService.UpdateAsync(admin);

                return RedirectToAction(nameof(Index));
            }

            return View(admin);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var admin = await _adminService.GetByIdAsync(id.Value);

            if (admin == null)
                return NotFound();

            return View(admin);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _adminService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/EventRequests
        public async Task<IActionResult> EventRequests()
        {
            var eventRequests =
                await _adminService.GetEventRequestsAsync();

            return View(eventRequests);
        }

        // GET: Admin/ReviewEventRequest/5
        public async Task<IActionResult> ReviewEventRequest(int? id)
        {
            if (id == null)
                return NotFound();

            var eventRequest =
                await _adminService.GetEventRequestByIdAsync(id.Value);

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
            var eventRequest =
                await _adminService.GetEventRequestByIdAsync(EventRequestID);

            if (eventRequest == null)
                return NotFound();

            await _adminService.ReviewEventRequestAsync(
                EventRequestID,
                AdminID,
                AdminResponse);

            return RedirectToAction(nameof(EventRequests));
        }
    }
}