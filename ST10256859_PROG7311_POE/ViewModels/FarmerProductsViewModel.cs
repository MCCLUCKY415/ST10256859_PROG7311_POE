using System;
using System.Collections.Generic;
using ST10256859_PROG7311_POE.Models;

namespace ST10256859_PROG7311_POE.ViewModels
{
    public class FarmerProductsViewModel
    {
        public List<Farmer> Farmers { get; set; }
        public int? SelectedFarmerId { get; set; }
        public List<Product> Products { get; set; }
        public string SelectedCategory { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<string> Categories { get; set; }
    }
}
