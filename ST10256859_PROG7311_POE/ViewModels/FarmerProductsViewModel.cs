// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - GitHub Copilot for assisting with the structure of the code.
// - ChatGPT for assisting me with finding and fixing errors in the code.

using System;
using System.Collections.Generic;
using ST10256859_PROG7311_POE.Models;

namespace ST10256859_PROG7311_POE.ViewModels
{
    // ViewModel for displaying products by farmers (for employees)
    public class FarmerProductsViewModel
    {
        public List<Farmer> Farmers { get; set; }           // List of all farmers
        public int? SelectedFarmerId { get; set; }          // Currently selected farmer ID
        public List<Product> Products { get; set; }         // List of products to display
        public string SelectedCategory { get; set; }        // Currently selected product category
        public DateTime? StartDate { get; set; }            // Filter: start date
        public DateTime? EndDate { get; set; }              // Filter: end date
        public List<string> Categories { get; set; }        // List of available product categories
    }
}
