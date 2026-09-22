using System.ComponentModel.DataAnnotations;

namespace Project.ViewModels
{
    public class CustomizedBouquetViewModel
    {
        [Required]
        public int SizeID { get; set; }

        [Required]
        public int WrappingID { get; set; }

        public List<int> FlowerIDs { get; set; } = new List<int>();

        public List<int> FlowerColorIDs { get; set; } = new List<int>();

        public List<int> AddOnIDs { get; set; } = new List<int>();

        public Dictionary<int, int> FlowerQuantities { get; set; }
            = new Dictionary<int, int>();

        public int CustomerID { get; set; }
    }
}