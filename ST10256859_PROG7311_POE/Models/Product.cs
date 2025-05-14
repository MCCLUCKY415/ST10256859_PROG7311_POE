// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - GitHub Copilot for assisting with the structure of the code.
// - ChatGPT for assisting me with finding and fixing errors in the code.

namespace ST10256859_PROG7311_POE.Models
{
    // Represents a product listed by a farmer
    public class Product
    {
        public int ProductID { get; set; }              // Unique identifier for the product
        public string ProductName { get; set; }         // Name of the product
        public string Category { get; set; }            // Product category (e.g., Fruit, Vegetable)
        public decimal ProductPrice { get; set; }       // Price of the product
        public int AvailableQuantity { get; set; }      // Quantity available for sale
        public string? Description { get; set; }        // Optional description of the product
        public DateTime ProductionDate { get; set; }    // Date the product was produced
        public byte[]? ProductImage { get; set; }       // Image of the product (stored as byte array)

        public int FarmerID { get; set; }               // Foreign key to the owning farmer
        public Farmer Farmer { get; set; }              // Navigation property to the farmer
    }
}
