using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities.Data;
using Project.DAL.Entities;
using Project.ViewModels;

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

        public IActionResult Create()
        {
            var model = new EventRequestCreateViewModel
            {
                Customers = _context.Customers
                    .Select(c => new SelectListItem
                    {
                        Value = c.CustomerID.ToString(),
                        Text = c.FullName
                    })
                    .ToList(),

                Occasions = _context.Occasions
                    .Select(o => new SelectListItem
                    {
                        Value = o.OccasionID.ToString(),
                        Text = o.Name
                    })
                    .ToList(),

                DecorationTypes = _context.DecorationTypes
                    .Select(d => new SelectListItem
                    {
                        Value = d.DecorationTypeID.ToString(),
                        Text = d.Name
                    })
                    .ToList()
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var eventRequest = _context.EventRequests
                .Include(e => e.Customer)
                .Include(e => e.Occasion)
                .Include(e => e.Admin)
                .Include(e => e.EventRequestDecorations)
                    .ThenInclude(ed => ed.DecorationType)
                .FirstOrDefault(e => e.EventRequestID == id);

            if (eventRequest == null)
            {
                return NotFound();
            }

            return View(eventRequest);
        }

        public IActionResult AdminReview(int id)
        {
            var eventRequest = _context.EventRequests
                .FirstOrDefault(e => e.EventRequestID == id);

            if (eventRequest == null)
            {
                return NotFound();
            }

            var model = new EventRequestReviewViewModel
            {
                EventRequestID = eventRequest.EventRequestID,
                LocationType = eventRequest.LocationType,
                NumberOfGuests = eventRequest.NumberOfGuests,
                EventDate = eventRequest.EventDate,
                Theme = eventRequest.Theme,
                Budget = eventRequest.Budget,
                Status = eventRequest.Status,
                AdminResponse = eventRequest.AdminResponse,

                Admins = _context.Admins
                    .Select(a => new SelectListItem
                    {
                        Value = a.AdminID.ToString(),
                        Text = a.FullName
                    })
                    .ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdminReview(EventRequestReviewViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Admins = _context.Admins
                    .Select(a => new SelectListItem
                    {
                        Value = a.AdminID.ToString(),
                        Text = a.FullName
                    })
                    .ToList();

                return View(model);
            }

            var eventRequest = _context.EventRequests
                .FirstOrDefault(e => e.EventRequestID == model.EventRequestID);

            if (eventRequest == null)
            {
                return NotFound();
            }

            eventRequest.Status = model.Status;
            eventRequest.AdminResponse = model.AdminResponse;
            eventRequest.AdminID = model.AdminID;

            _context.SaveChanges();

            return RedirectToAction(nameof(Details), new { id = model.EventRequestID });
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EventRequestCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Customers = _context.Customers
                    .Select(c => new SelectListItem
                    {
                        Value = c.CustomerID.ToString(),
                        Text = c.FullName
                    })
                    .ToList();

                model.Occasions = _context.Occasions
                    .Select(o => new SelectListItem
                    {
                        Value = o.OccasionID.ToString(),
                        Text = o.Name
                    })
                    .ToList();

                model.DecorationTypes = _context.DecorationTypes
                    .Select(d => new SelectListItem
                    {
                        Value = d.DecorationTypeID.ToString(),
                        Text = d.Name
                    })
                    .ToList();

                return View(model);
            }

            var eventRequest = new EventRequest
            {
                LocationType = model.LocationType,
                NumberOfGuests = model.NumberOfGuests,
                EventDate = model.EventDate,
                Theme = model.Theme,
                Budget = model.Budget,
                CustomerID = model.CustomerID,
                OccasionID = model.OccasionID,
                Status = "Pending"
            };

            _context.EventRequests.Add(eventRequest);
            _context.SaveChanges();

            foreach (var decorationTypeID in model.DecorationTypeIDs)
            {
                var decoration = new EventRequestDecoration
                {
                    EventRequestID = eventRequest.EventRequestID,
                    DecorationTypeID = decorationTypeID
                };

                _context.EventRequestDecorations.Add(decoration);
            }

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}