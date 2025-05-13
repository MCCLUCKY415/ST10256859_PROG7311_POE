using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10256859_PROG7311_POE.Models;
using ST10256859_PROG7311_POE.ViewModels;
using ST10256859_PROG7311_POE.DataBase;

namespace ST10256859_PROG7311_POE.Controllers
{
    public class FarmerController : Controller
    {
        private readonly AppDbContext _context;

        public FarmerController(AppDbContext context)
        {
            _context = context;
        }

        private bool IsFarmer()
        {
            return HttpContext.Session.GetString("UserRole") == "Farmer";
        }

        private byte[] GetDefaultProductImage()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "default_product.png");
            return System.IO.File.Exists(path) ? System.IO.File.ReadAllBytes(path) : null;
        }

        public IActionResult FarmerProfile()
        {
            if (!IsFarmer())
                return RedirectToAction("Login", "Home");

            var farmerIdString = HttpContext.Session.GetString("UserID");
            if (string.IsNullOrEmpty(farmerIdString))
            {
                return RedirectToAction("Login", "Home");
            }

            int farmerId = int.Parse(farmerIdString);

            var farmer = _context.Farmers
                .Include(f => f.Products)
                .FirstOrDefault(f => f.FarmerID == farmerId);

            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }


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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProductAdd(ProductAddViewModel model)
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
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("FarmerProfile");
            }
            return View(model);
        }
    }
}
