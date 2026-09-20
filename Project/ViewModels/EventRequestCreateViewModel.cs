using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Project.ViewModels
{
    public class EventRequestCreateViewModel
    {
        [Required]
        public string? LocationType { get; set; }

        [Required]
        [Range(1, 10000)]
        public int NumberOfGuests { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        public string? Theme { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Budget { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [Required]
        public int OccasionID { get; set; }

        public List<int> DecorationTypeIDs { get; set; } = new();

        public IEnumerable<SelectListItem>? Customers { get; set; }

        public IEnumerable<SelectListItem>? Occasions { get; set; }

        public IEnumerable<SelectListItem>? DecorationTypes { get; set; }
    }
}
