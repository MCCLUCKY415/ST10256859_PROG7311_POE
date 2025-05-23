﻿// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - GitHub Copilot for assisting with the structure of the code.
// - ChatGPT for assisting me with finding and fixing errors in the code.

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10256859_PROG7311_POE.Models;
using ST10256859_PROG7311_POE.ViewModels;
using ST10256859_PROG7311_POE.DataBase;

namespace ST10256859_PROG7311_POE.Controllers
{
    // Handles actions for Farmer users
    public class FarmerController : Controller
    {
        // Repositories for Farmer and Product entities
        private readonly IRepository<Farmer> _farmerRepo;
        private readonly IRepository<Product> _productRepo;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Constructor with dependency injection
        public FarmerController(IRepository<Farmer> farmerRepo, IRepository<Product> productRepo)
        {
            _farmerRepo = farmerRepo;
            _productRepo = productRepo;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Checks if the current user is a Farmer
        private bool IsFarmer()
        {
            return HttpContext.Session.GetString("UserRole") == "Farmer";
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Gets the default product image as a byte array
        private byte[] GetDefaultProductImage()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "default_product.png");
            return System.IO.File.Exists(path) ? System.IO.File.ReadAllBytes(path) : null;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Shows the profile of the logged-in farmer, with product filters
        public async Task<IActionResult> FarmerProfile(string category, DateTime? startDate, DateTime? endDate)
        {
            if (!IsFarmer())
                return RedirectToAction("Login", "Home");

            var farmerIdString = HttpContext.Session.GetString("UserID");
            if (string.IsNullOrEmpty(farmerIdString))
                return RedirectToAction("Login", "Home");

            int farmerId = int.Parse(farmerIdString);

            var farmer = await _farmerRepo.Query()
                .Include(f => f.Products)
                .FirstOrDefaultAsync(f => f.FarmerID == farmerId);

            if (farmer == null)
                return NotFound();

            var productsQuery = farmer.Products.AsQueryable();

            if (!string.IsNullOrEmpty(category))
                productsQuery = productsQuery.Where(p => p.Category == category);

            if (startDate.HasValue)
                productsQuery = productsQuery.Where(p => p.ProductionDate >= startDate.Value);

            if (endDate.HasValue)
                productsQuery = productsQuery.Where(p => p.ProductionDate <= endDate.Value);

            var categories = farmer.Products.Select(p => p.Category).Distinct().ToList();

            var viewModel = new ST10256859_PROG7311_POE.ViewModels.FarmerProfileViewModel
            {
                FarmerID = farmer.FarmerID,
                FirstName = farmer.FirstName,
                LastName = farmer.LastName,
                Email = farmer.Email,
                PhoneNumber = farmer.PhoneNumber,
                Address = farmer.Address,
                Products = productsQuery.ToList(),
                Categories = categories,
                SelectedCategory = category,
                StartDate = startDate,
                EndDate = endDate
            };

            return View(viewModel);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Shows the form to add a new product
        public IActionResult ProductAdd()
        {
            if (!IsFarmer())
                return RedirectToAction("Login", "Home");

            // Get FarmerID from session
            var farmerIdString = HttpContext.Session.GetString("UserID");
            if (string.IsNullOrEmpty(farmerIdString))
            {
                // Not logged in as farmer, redirect or show error
                return RedirectToAction("Login", "Home");
            }

            var model = new ProductAddViewModel
            {
                FarmerID = int.Parse(farmerIdString)
            };
            return View(model);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Handles the POST request to add a new product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductAdd(ProductAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                byte[] imageData = null;
                if (model.ProductImage != null && model.ProductImage.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        model.ProductImage.CopyTo(ms);
                        imageData = ms.ToArray();
                    }
                }
                else
                {
                    imageData = GetDefaultProductImage();
                }

                var product = new Product
                {
                    ProductName = model.ProductName,
                    Category = model.Category,
                    ProductionDate = model.ProductionDate,
                    ProductPrice = model.ProductPrice,
                    AvailableQuantity = model.AvailableQuantity,
                    Description = model.Description,
                    FarmerID = model.FarmerID,
                    ProductImage = imageData
                };
                await _productRepo.AddAsync(product);
                await _productRepo.SaveAsync();
                return RedirectToAction("FarmerProfile");
            }
            return View(model);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
