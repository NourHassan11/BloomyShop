using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using Project.DAL.Entities.Data;

namespace Project.Controllers
{
    public class CartController : Controller
    {
        private readonly BloomyShopDbContext _context;

        public CartController(BloomyShopDbContext context)
        {
            _context = context;
        }

        // GET: Cart
        public async Task<IActionResult> Index()
        {
            int? customerId = HttpContext.Session.GetInt32("CustomerID");

            if (customerId == null)
            {
                return RedirectToAction("Login", "Customer");
            }

            var cart = await _context.Carts
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Bouquet)
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.CustomizedBouquet)
                .FirstOrDefaultAsync(c => c.CustomerID == customerId.Value);

            if (cart == null || !cart.CartItems.Any())
            {
                return View("EmptyCart");
            }

            return View(cart);
        }

        // POST: Cart/AddToCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int bouquetId)
        {
            int? customerId = HttpContext.Session.GetInt32("CustomerID");

            if (customerId == null)
            {
                return RedirectToAction("Login", "Customer");
            }

            var bouquet = await _context.Bouquets
                .FirstOrDefaultAsync(b => b.BouquetID == bouquetId && b.IsActive);

            if (bouquet == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.CustomerID == customerId.Value);

            if (cart == null)
            {
                cart = new Cart
                {
                    CustomerID = customerId.Value
                };

                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            var existingItem = cart.CartItems
                .FirstOrDefault(ci => ci.BouquetID == bouquetId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                var cartItem = new CartItem
                {
                    CartID = cart.CartID,
                    BouquetID = bouquet.BouquetID,
                    Quantity = 1,
                    UnitPrice = bouquet.Price
                };

                _context.CartItems.Add(cartItem);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: Cart/UpdateQuantity
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateQuantity(int id, int quantity)
        {
            int? customerId = HttpContext.Session.GetInt32("CustomerID");

            if (customerId == null)
            {
                return RedirectToAction("Login", "Customer");
            }

            var cartItem = await _context.CartItems
                .Include(ci => ci.Cart)
                .FirstOrDefaultAsync(ci =>
                    ci.CartItemID == id &&
                    ci.Cart.CustomerID == customerId.Value);

            if (cartItem == null)
            {
                return NotFound();
            }

            if (quantity <= 0)
            {
                _context.CartItems.Remove(cartItem);
            }
            else
            {
                cartItem.Quantity = quantity;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: Cart/RemoveFromCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            int? customerId = HttpContext.Session.GetInt32("CustomerID");

            if (customerId == null)
            {
                return RedirectToAction("Login", "Customer");
            }

            var cartItem = await _context.CartItems
                .Include(ci => ci.Cart)
                .FirstOrDefaultAsync(ci =>
                    ci.CartItemID == id &&
                    ci.Cart.CustomerID == customerId.Value);

            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCustomizedToCart(int customizationId)
        {
            int? customerId = HttpContext.Session.GetInt32("CustomerID");

            if (customerId == null)
            {
                return RedirectToAction("Login", "Customer");
            }

            var customizedBouquet = await _context.CustomizedBouquets
                .Include(c => c.BouquetSize)
                .Include(c => c.Wrapping)
                .Include(c => c.CustomizedBouquetFlowers)
                    .ThenInclude(x => x.Flower)
                .Include(c => c.CustomizedBouquetAddOns)
                    .ThenInclude(x => x.AddOn)
                .FirstOrDefaultAsync(c =>
                    c.CustomizationID == customizationId &&
                    c.CustomerID == customerId.Value);

            if (customizedBouquet == null)
            {
                return NotFound();
            }

            decimal totalPrice =
                customizedBouquet.BouquetSize.BasePrice
                + customizedBouquet.Wrapping.Price
                + customizedBouquet.CustomizedBouquetFlowers
                    .Sum(x => x.Flower.BasePrice)
                + customizedBouquet.CustomizedBouquetAddOns
                    .Sum(x => x.AddOn.Price);

            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c =>
                    c.CustomerID == customerId.Value);

            if (cart == null)
            {
                cart = new Cart
                {
                    CustomerID = customerId.Value
                };

                _context.Carts.Add(cart);

                await _context.SaveChangesAsync();
            }

            var cartItem = new CartItem
            {
                CartID = cart.CartID,
                CustomizedBouquetID = customizedBouquet.CustomizationID,
                Quantity = 1,
                UnitPrice = totalPrice
            };

            _context.CartItems.Add(cartItem);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}