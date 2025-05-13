using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10256859_PROG7311_POE.DataBase;
using ST10256859_PROG7311_POE.Models;
using ST10256859_PROG7311_POE.ViewModels;

namespace ST10256859_PROG7311_POE.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        private bool IsEmployee()
        {
            return HttpContext.Session.GetString("UserRole") == "Employee";
        }

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult EmployeeProfile()
        {
            if (!IsEmployee())
                return RedirectToAction("Login", "Home");

            var employeeIdString = HttpContext.Session.GetString("UserID");
            if (string.IsNullOrEmpty(employeeIdString))
            {
                return RedirectToAction("Login", "Home");
            }

            int employeeId = int.Parse(employeeIdString);
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }



        public IActionResult FarmerProducts(int? farmerId, string category, DateTime? startDate, DateTime? endDate)
        {
            if (!IsEmployee())
                return RedirectToAction("Login", "Home");

            var farmers = _context.Farmers.ToList();
            var categories = _context.Products.Select(p => p.Category).Distinct().ToList();

            var productsQuery = _context.Products.Include(p => p.Farmer).AsQueryable();

            if (farmerId.HasValue)
                productsQuery = productsQuery.Where(p => p.FarmerID == farmerId.Value);

            if (!string.IsNullOrEmpty(category))
                productsQuery = productsQuery.Where(p => p.Category == category);

            if (startDate.HasValue)
                productsQuery = productsQuery.Where(p => p.ProductionDate >= startDate.Value);

            if (endDate.HasValue)
                productsQuery = productsQuery.Where(p => p.ProductionDate <= endDate.Value);

            var viewModel = new FarmerProductsViewModel
            {
                Farmers = farmers,
                SelectedFarmerId = farmerId,
                Products = productsQuery.ToList(),
                SelectedCategory = category,
                StartDate = startDate,
                EndDate = endDate,
                Categories = categories
            };

            return View(viewModel);
        }


        public IActionResult FarmerAdd()
        {
            if (!IsEmployee())
                return RedirectToAction("Login", "Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FarmerAdd(FarmerAddViewModel model)
        {
            if (!IsEmployee())
                return RedirectToAction("Login", "Home");

            if (ModelState.IsValid)
            {
                // Check if email already exists
                bool farmerExists = _context.Farmers.Any(f => f.Email == model.Email);
                if (farmerExists)
                {
                    ModelState.AddModelError("", "A farmer with this email already exists.");
                    return View(model);
                }

                var farmer = new Farmer
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    Password = model.Password
                };

                _context.Farmers.Add(farmer);
                _context.SaveChanges();
                return RedirectToAction("FarmerProducts");
            }
            return View(model);
        }

    }
}
