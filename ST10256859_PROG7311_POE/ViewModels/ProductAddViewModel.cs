// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - GitHub Copilot for assisting with the structure of the code.
// - ChatGPT for assisting me with finding and fixing errors in the code.

using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ST10256859_PROG7311_POE.ViewModels
{
    // ViewModel for adding a new product
    public class ProductAddViewModel
    {
        [Required(ErrorMessage = "Please enter the product name.")]
        [Display(Name = "Product Name (Max 200 Characters)")]
        [MaxLength(200, ErrorMessage = "Product name cannot exceed 200 characters.")]
        public string ProductName { get; set; }             // Name of the product

        [Required(ErrorMessage = "Please enter the category.")]
        [Display(Name = "Category (Max 100 Characters)")]
        [MaxLength(100, ErrorMessage = "Category cannot exceed 100 characters.")]
        public string Category { get; set; }                // Product category

        [Required(ErrorMessage = "Please enter the production date.")]
        [Display(Name = "Production Date")]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }        // Date the product was produced

        [Required(ErrorMessage = "Please enter the product price.")]
        [Display(Name = "Product Price (Rands)")]
        [Range(0.01, 999999999, ErrorMessage = "Product price must be greater than 0 and less than or equal to 999,999,999.")]
        public decimal ProductPrice { get; set; }           // Price of the product

        [Required(ErrorMessage = "Please enter the available quantity.")]
        [Display(Name = "Product Quantity")]
        [Range(1, 999999999, ErrorMessage = "Available quantity must be between 1 and 999,999,999.")]
        public int AvailableQuantity { get; set; }          // Quantity available

        [MaxLength(250, ErrorMessage = "Description cannot exceed 250 characters.")]
        [Display(Name = "Product Description (Max 250 Characters)")]
        public string? Description { get; set; }            // Optional product description

        [Display(Name = "Product Image (jpg, jpeg, png)")]
        public IFormFile? ProductImage { get; set; }        // Uploaded product image

        public int FarmerID { get; set; }                   // ID of the farmer adding the product
    }
}
