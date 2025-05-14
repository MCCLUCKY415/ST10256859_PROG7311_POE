// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - GitHub Copilot for assisting with the structure of the code.
// - ChatGPT for assisting me with finding and fixing errors in the code.

namespace ST10256859_PROG7311_POE.Models
{
    // Represents a farmer in the system
    public class Farmer
    {
        public int FarmerID { get; set; }               // Unique identifier for the farmer
        public string FirstName { get; set; }           // Farmer's first name
        public string LastName { get; set; }            // Farmer's last name
        public string PhoneNumber { get; set; }         // Farmer's phone number
        public string Address { get; set; }             // Farmer's address
        public string Email { get; set; }               // Farmer's email address
        public string Password { get; set; }            // Farmer's password

        public ICollection<Product> Products { get; set; } // Collection of products owned by the farmer
    }
}
