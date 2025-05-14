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
    // ViewModel for displaying a farmer's profile and their products
    public class FarmerProfileViewModel
    {
        public int FarmerID { get; set; }                   // Farmer's unique ID
        public string FirstName { get; set; }               // Farmer's first name
        public string LastName { get; set; }                // Farmer's last name
        public string Email { get; set; }                   // Farmer's email address
        public string PhoneNumber { get; set; }             // Farmer's phone number
        public string Address { get; set; }                 // Farmer's address

        public List<Product> Products { get; set; }         // List of products owned by the farmer
        public List<string> Categories { get; set; }        // List of product categories
        public string SelectedCategory { get; set; }        // Currently selected category filter
        public DateTime? StartDate { get; set; }            // Filter: start date
        public DateTime? EndDate { get; set; }              // Filter: end date
    }
}
