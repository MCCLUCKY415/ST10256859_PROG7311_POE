using System;
using System.ComponentModel.DataAnnotations;

namespace ST10256859_PROG7311_POE.ViewModels
{
    public class ProductAddViewModel
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal ProductPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int AvailableQuantity { get; set; }

        public string? Description { get; set; }

        public IFormFile? ProductImage { get; set; }


        public int FarmerID { get; set; }
    }
}
