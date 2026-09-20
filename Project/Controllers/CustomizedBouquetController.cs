using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using Project.DAL.Entities.Data;
using Project.ViewModels;

namespace Project.Controllers
{
    public class CustomizedBouquetController : Controller
    {
        private readonly BloomyShopDbContext _context;

        public CustomizedBouquetController(BloomyShopDbContext context)
        {
            _context = context;
        }


        // GET: CustomizedBouquet/Customize
        [HttpGet]
        public async Task<IActionResult> Customize()
        {
            await LoadData();

            return View(new CustomizedBouquetViewModel());
        }


        // POST: CustomizedBouquet/Customize
        [HttpPost]
        public async Task<IActionResult> Customize(CustomizedBouquetViewModel model)
        {
            if (model.FlowerIDs == null || model.FlowerIDs.Count == 0)
            {
                ModelState.AddModelError(
                    "FlowerIDs",
                    "Please select at least one flower."
                );
            }


            // Color Validation
            if (model.FlowerColorIDs != null &&
                model.FlowerColorIDs.Count > 0)
            {
                var colors = await _context.FlowerColors
                    .Where(c => model.FlowerColorIDs.Contains(c.FlowerColorID))
                    .ToListAsync();

                foreach (var color in colors)
                {
                    if (!model.FlowerIDs.Contains(color.FlowerID))
                    {
                        ModelState.AddModelError(
                            "FlowerColorIDs",
                            "The selected color does not belong to the selected flower."
                        );
                    }
                }
            }


            if (!ModelState.IsValid)
            {
                await LoadData();

                return View(model);
            }


            // Get Size
            var size = await _context.BouquetSizes
                .FirstOrDefaultAsync(s => s.SizeID == model.SizeID);

            if (size == null)
            {
                return NotFound();
            }


            // Get Wrapping
            var wrapping = await _context.Wrappings
                .FirstOrDefaultAsync(w => w.WrappingID == model.WrappingID);

            if (wrapping == null)
            {
                return NotFound();
            }


            // Get Flowers
            var flowers = await _context.Flowers
                .Where(f => model.FlowerIDs.Contains(f.FlowerID))
                .ToListAsync();


            // Get AddOns
            var addOns = await _context.AddOns
                .Where(a => model.AddOnIDs.Contains(a.AddOnID))
                .ToListAsync();


            // Dynamic Pricing
            decimal totalPrice = size.BasePrice;

            totalPrice += wrapping.Price;

            foreach (var flower in flowers)
            {
                totalPrice += flower.BasePrice;
            }

            foreach (var addOn in addOns)
            {
                totalPrice += addOn.Price;
            }


            // Preparation Time
            int preparationTime = 30;

            preparationTime += flowers.Count * 10;

            preparationTime += addOns.Count * 5;


            // Create Customized Bouquet
            var customizedBouquet = new CustomizedBouquet
            {
                CreatedAt = DateTime.Now,

                PreparationTime = preparationTime,

                CustomerID = model.CustomerID,

                SizeID = model.SizeID,

                WrappingID = model.WrappingID
            };


            _context.CustomizedBouquets.Add(customizedBouquet);

            await _context.SaveChangesAsync();


            // Add Flowers
            foreach (var flowerID in model.FlowerIDs)
            {
                var item = new CustomizedBouquetFlower
                {
                    CustomizationID = customizedBouquet.CustomizationID,

                    FlowerID = flowerID
                };

                _context.CustomizedBouquetFlowers.Add(item);
            }


            // Add Colors
            if (model.FlowerColorIDs != null)
            {
                foreach (var colorID in model.FlowerColorIDs)
                {
                    var item = new CustomizedBouquetFlowerColor
                    {
                        CustomizationID = customizedBouquet.CustomizationID,

                        FlowerColorID = colorID
                    };

                    _context.CustomizedBouquetFlowerColors.Add(item);
                }
            }


            // Add AddOns
            if (model.AddOnIDs != null)
            {
                foreach (var addOnID in model.AddOnIDs)
                {
                    var item = new CustomizedBouquetAddOn
                    {
                        CustomizationID = customizedBouquet.CustomizationID,

                        AddOnID = addOnID
                    };

                    _context.CustomizedBouquetAddOns.Add(item);
                }
            }


            await _context.SaveChangesAsync();


            return RedirectToAction(
                "Preview",
                new
                {
                    id = customizedBouquet.CustomizationID
                }
            );
        }


        // GET: CustomizedBouquet/Preview/5
        [HttpGet]
        public async Task<IActionResult> Preview(int id)
        {
            var customizedBouquet =
                await _context.CustomizedBouquets

                .Include(c => c.BouquetSize)

                .Include(c => c.Wrapping)

                .Include(c => c.CustomizedBouquetFlowers)
                    .ThenInclude(x => x.Flower)

                .Include(c => c.CustomizedBouquetFlowerColors)
                    .ThenInclude(x => x.FlowerColor)

                .Include(c => c.CustomizedBouquetAddOns)
                    .ThenInclude(x => x.AddOn)

                .FirstOrDefaultAsync(
                    c => c.CustomizationID == id
                );


            if (customizedBouquet == null)
            {
                return NotFound();
            }


            ViewBag.TotalPrice =
                customizedBouquet.BouquetSize.BasePrice
                + customizedBouquet.Wrapping.Price

                + customizedBouquet.CustomizedBouquetFlowers
                    .Sum(x => x.Flower.BasePrice)

                + customizedBouquet.CustomizedBouquetAddOns
                    .Sum(x => x.AddOn.Price);


            return View(customizedBouquet);
        }


        private async Task LoadData()
        {
            ViewBag.Sizes =
                await _context.BouquetSizes.ToListAsync();

            ViewBag.Wrappings =
                await _context.Wrappings.ToListAsync();

            ViewBag.Flowers =
                await _context.Flowers.ToListAsync();

            ViewBag.Colors =
                await _context.FlowerColors.ToListAsync();

            ViewBag.AddOns =
                await _context.AddOns.ToListAsync();
        }
    }
}
