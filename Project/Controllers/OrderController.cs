using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using Project.DAL.Entities.Data;

namespace Project.Controllers
{
    public class OrderController : Controller
    {
        private readonly BloomyShopDbContext _context;

        public OrderController(BloomyShopDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            int customerId = 1;

            var cart = _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefault(c => c.CustomerID == customerId);

            if (cart == null || !cart.CartItems.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            return View(new Order { DeliveryAddress = string.Empty });
        }

        [HttpPost]
        public IActionResult Checkout(Order orderModel)
        {
            int customerId = 1;

            var cart = _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefault(c => c.CustomerID == customerId);

            if (cart == null || !cart.CartItems.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            orderModel.CustomerID = customerId;
            orderModel.OrderDate = DateTime.Now;
            orderModel.Status = "Pending";
            orderModel.TotalPrice = cart.CartItems.Sum(ci => ci.UnitPrice * ci.Quantity);

            orderModel.OrderItems = cart.CartItems.Select(ci => new OrderItem
            {
                BouquetID = ci.BouquetID,
                CustomizedBouquetID = ci.CustomizedBouquetID,
                Quantity = ci.Quantity,
                UnitPrice = ci.UnitPrice
            }).ToList();

            _context.Orders.Add(orderModel);
            _context.CartItems.RemoveRange(cart.CartItems);
            _context.SaveChanges();

            return RedirectToAction("Index", "Order");
        }

        public IActionResult Index()
        {
            int customerId = 1;

            var orders = _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Bouquet)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.CustomizedBouquet)
                .Where(o => o.CustomerID == customerId)
                .ToList();

            return View(orders);
        }

        public IActionResult Details(int id)
        {
            int customerId = 1;

            var order = _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Bouquet)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.CustomizedBouquet)
                .FirstOrDefault(o => o.OrderID == id && o.CustomerID == customerId);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // Admin: View all customer orders
        public IActionResult AdminOrders()
        {
            var orders = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Bouquet)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.CustomizedBouquet)
                .ToList();

            return View(orders);
        }

        // Admin: Update order status
        [HttpPost]
        public IActionResult UpdateStatus(int orderId, string status)
        {
            var order = _context.Orders.Find(orderId);
            if (order != null)
            {
                order.Status = status;
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(AdminOrders));
        }
    }
}