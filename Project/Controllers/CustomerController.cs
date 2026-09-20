using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using Project.DAL.Entities.Data;

namespace Project.Controllers
{
    public class CustomerController : Controller
    {
        private readonly BloomyShopDbContext _context;

        public CustomerController(BloomyShopDbContext context)
        {
            _context = context;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            var customers = await _context.Customers
                .AsNoTracking()
                .ToListAsync();

            return View(customers);
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var customer = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CustomerID == id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.FullName = customer.FName + " " + customer.Lname;

                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (id != customer.CustomerID)
                return NotFound();

            if (ModelState.IsValid)
            {
                customer.FullName = customer.FName + " " + customer.Lname;

                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var customer = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CustomerID == id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Customer/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Customer/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c =>
                    c.Email == email &&
                    c.Password == password);

            if (customer == null)
            {
                ViewBag.Error = "Invalid email or password.";
                return View();
            }

            HttpContext.Session.SetInt32(
                "CustomerID",
                customer.CustomerID);

            HttpContext.Session.SetString(
                "CustomerName",
                customer.FullName);

            return RedirectToAction(
                nameof(Profile),
                new { id = customer.CustomerID });
        }

        // GET: Customer/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Customer/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var existingCustomer = await _context.Customers
                    .FirstOrDefaultAsync(c =>
                        c.Email == customer.Email);

                if (existingCustomer != null)
                {
                    ViewBag.Error = "Email already exists.";
                    return View(customer);
                }

                customer.FullName =
                    customer.FName + " " + customer.Lname;

                _context.Customers.Add(customer);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Login));
            }

            return View(customer);
        }

        // GET: Customer/Profile/5
        public async Task<IActionResult> Profile(int? id)
        {
            if (id == null)
                return NotFound();

            var customer = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c =>
                    c.CustomerID == id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }
    }
}