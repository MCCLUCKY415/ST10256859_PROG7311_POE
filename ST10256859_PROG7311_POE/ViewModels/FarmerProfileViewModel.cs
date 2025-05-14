using System;
using System.Collections.Generic;
using ST10256859_PROG7311_POE.Models;

namespace ST10256859_PROG7311_POE.ViewModels
{
    public class FarmerProfileViewModel
    {
        public int FarmerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public List<Product> Products { get; set; }
        public List<string> Categories { get; set; }
        public string SelectedCategory { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
