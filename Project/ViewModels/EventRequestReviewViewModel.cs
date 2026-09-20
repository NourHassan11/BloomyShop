using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Project.ViewModels
{
    public class EventRequestReviewViewModel
    {
        public int EventRequestID { get; set; }

        public string? LocationType { get; set; }

        public int NumberOfGuests { get; set; }

        public DateTime EventDate { get; set; }

        public string? Theme { get; set; }

        public decimal Budget { get; set; }

        public string? Status { get; set; }

        [Required]
        public string? AdminResponse { get; set; }

        [Required]
        public int AdminID { get; set; }

        public IEnumerable<SelectListItem>? Admins { get; set; }
    }
}