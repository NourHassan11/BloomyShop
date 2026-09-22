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
        public async Task<IActionResult> Customize(
            CustomizedBouquetViewModel model)
        {
            // Make sure lists are not null
            model.FlowerIDs ??= new List<int>();
            model.FlowerColorIDs ??= new List<int>();
            model.AddOnIDs ??= new List<int>();
            model.FlowerQuantities ??= new Dictionary<int, int>();


            // =========================
            // FLOWER VALIDATION
            // =========================

            var selectedFlowers = model.FlowerQuantities
                .Where(x => x.Value > 0)
                .Select(x => x.Key)
                .ToList();

            if (selectedFlowers.Count == 0)
            {
                ModelState.AddModelError(
                    "FlowerIDs",
                    "Please select at least one flower."
                );
            }

            // Keep FlowerIDs synchronized with quantities
            model.FlowerIDs = selectedFlowers;


            // =========================
            // COLOR VALIDATION
            // =========================

            if (model.FlowerColorIDs.Count > 0 &&
                model.FlowerIDs.Count > 0)
            {
                var colors = await _context.FlowerColors
                    .Where(c =>
                        model.FlowerColorIDs.Contains(c.FlowerColorID))
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


            // =========================
            // MODEL VALIDATION
            // =========================

            if (!ModelState.IsValid)
            {
                await LoadData();

                return View(model);
            }


            // =========================
            // GET SIZE
            // =========================

            var size = await _context.BouquetSizes
                .FirstOrDefaultAsync(
                    s => s.SizeID == model.SizeID
                );

            if (size == null)
            {
                return NotFound();
            }


            // =========================
            // GET WRAPPING
            // =========================

            var wrapping = await _context.Wrappings
                .FirstOrDefaultAsync(
                    w => w.WrappingID == model.WrappingID
                );

            if (wrapping == null)
            {
                return NotFound();
            }


            // =========================
            // GET FLOWERS
            // =========================

            var flowers = await _context.Flowers
                .Where(f => model.FlowerIDs.Contains(f.FlowerID))
                .ToListAsync();


            // =========================
            // GET ADDONS
            // =========================

            var addOns = await _context.AddOns
                .Where(a => model.AddOnIDs.Contains(a.AddOnID))
                .ToListAsync();


            // =========================
            // DYNAMIC PRICING
            // =========================

            decimal totalPrice = size.BasePrice;

            totalPrice += wrapping.Price;


            foreach (var flower in flowers)
            {
                int quantity = 1;

                if (model.FlowerQuantities.ContainsKey(
                    flower.FlowerID))
                {
                    quantity = model.FlowerQuantities[
                        flower.FlowerID];
                }

                totalPrice += flower.BasePrice * quantity;
            }


            foreach (var addOn in addOns)
            {
                totalPrice += addOn.Price;
            }


            // =========================
            // PREPARATION TIME
            // =========================

            int preparationTime = 30;

            foreach (var flower in flowers)
            {
                int quantity = 1;

                if (model.FlowerQuantities.ContainsKey(
                    flower.FlowerID))
                {
                    quantity = model.FlowerQuantities[
                        flower.FlowerID];
                }

                preparationTime += quantity * 10;
            }

            preparationTime += addOns.Count * 5;


            // =========================
            // CREATE CUSTOMIZED BOUQUET
            // =========================

            var customizedBouquet = new CustomizedBouquet
            {
                CreatedAt = DateTime.Now,

                PreparationTime = preparationTime,

                // Temporary customer until real login is connected
                CustomerID = 1,

                SizeID = model.SizeID,

                WrappingID = model.WrappingID
            };


            _context.CustomizedBouquets.Add(customizedBouquet);

            await _context.SaveChangesAsync();


            // =========================
            // ADD FLOWERS + QUANTITY
            // =========================

            foreach (var flowerID in model.FlowerIDs)
            {
                int quantity = 1;

                if (model.FlowerQuantities.ContainsKey(flowerID))
                {
                    quantity = model.FlowerQuantities[flowerID];
                }

                var item = new CustomizedBouquetFlower
                {
                    CustomizationID =
                        customizedBouquet.CustomizationID,

                    FlowerID = flowerID,

                    Quantity = quantity
                };

                _context.CustomizedBouquetFlowers.Add(item);
            }


            // =========================
            // ADD COLORS
            // =========================

            foreach (var colorID in model.FlowerColorIDs)
            {
                var item = new CustomizedBouquetFlowerColor
                {
                    CustomizationID =
                        customizedBouquet.CustomizationID,

                    FlowerColorID = colorID
                };

                _context.CustomizedBouquetFlowerColors.Add(item);
            }


            // =========================
            // ADD ADDONS
            // =========================

            foreach (var addOnID in model.AddOnIDs)
            {
                var item = new CustomizedBouquetAddOn
                {
                    CustomizationID =
                        customizedBouquet.CustomizationID,

                    AddOnID = addOnID
                };

                _context.CustomizedBouquetAddOns.Add(item);
            }


            await _context.SaveChangesAsync();


            // =========================
            // REDIRECT TO PREVIEW
            // =========================

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


            // =========================
            // TOTAL PRICE
            // =========================

            decimal totalPrice =
                customizedBouquet.BouquetSize.BasePrice
                + customizedBouquet.Wrapping.Price;


            foreach (
                var flower
                in customizedBouquet.CustomizedBouquetFlowers)
            {
                totalPrice +=
                    flower.Flower.BasePrice
                    * flower.Quantity;
            }


            totalPrice +=
                customizedBouquet.CustomizedBouquetAddOns
                    .Sum(x => x.AddOn.Price);


            ViewBag.TotalPrice = totalPrice;


            return View(customizedBouquet);
        }


        // =========================
        // LOAD DATA
        // =========================

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


