using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index()
        {
            int customerId = 1;

            var cart = _context.Carts
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Bouquet)
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.CustomizedBouquet)
                .FirstOrDefault(c => c.CustomerID == customerId);

            if (cart == null || cart.CartItems.Count == 0)
            {
                return View("EmptyCart");
            }

            return View(cart);
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            int customerId = 1;

            var cartItem = _context.CartItems
                .Include(ci => ci.Cart)
                .FirstOrDefault(ci => ci.CartItemID == id && ci.Cart.CustomerID == customerId);

            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}