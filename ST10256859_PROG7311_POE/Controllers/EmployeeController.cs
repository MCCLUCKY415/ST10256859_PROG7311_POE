// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - GitHub Copilot for assisting with the structure of the code.
// - ChatGPT for assisting me with finding and fixing errors in the code.

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10256859_PROG7311_POE.DataBase;
using ST10256859_PROG7311_POE.Models;
using ST10256859_PROG7311_POE.ViewModels;

namespace ST10256859_PROG7311_POE.Controllers
{
    // Handles actions for Employee users
    public class EmployeeController : Controller
    {
        // Repositories for Employee, Farmer, and Product entities
        private readonly IRepository<Employee> _employeeRepo;
        private readonly IRepository<Farmer> _farmerRepo;
        private readonly IRepository<Product> _productRepo;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Constructor with dependency injection
        public EmployeeController(
            IRepository<Employee> employeeRepo,
            IRepository<Farmer> farmerRepo,
            IRepository<Product> productRepo)
        {
            _employeeRepo = employeeRepo;
            _farmerRepo = farmerRepo;
            _productRepo = productRepo;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Checks if the current user is an Employee
        private bool IsEmployee()
        {
            return HttpContext.Session.GetString("UserRole") == "Employee";
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Shows the profile of the logged-in employee
        public async Task<IActionResult> EmployeeProfile()
        {
            if (!IsEmployee())
                return RedirectToAction("Login", "Home");

            var employeeIdString = HttpContext.Session.GetString("UserID");
            if (string.IsNullOrEmpty(employeeIdString))
                return RedirectToAction("Login", "Home");

            int employeeId = int.Parse(employeeIdString);
            var employee = await _employeeRepo.Query().FirstOrDefaultAsync(e => e.EmployeeID == employeeId);

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Shows products for a selected farmer, with optional filters
        public async Task<IActionResult> FarmerProducts(int? farmerId, string category, DateTime? startDate, DateTime? endDate)
        {
            if (!IsEmployee())
                return RedirectToAction("Login", "Home");

            var farmers = await _farmerRepo.GetAllAsync();
            var categories = _productRepo.Query().Select(p => p.Category).Distinct().ToList();

            var productsQuery = _productRepo.Query().Include(p => p.Farmer) as IQueryable<Product>;

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
                Farmers = farmers.ToList(),
                SelectedFarmerId = farmerId,
                Products = await productsQuery.ToListAsync(),
                SelectedCategory = category,
                StartDate = startDate,
                EndDate = endDate,
                Categories = categories
            };

            return View(viewModel);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Shows the form to add a new farmer
        public IActionResult FarmerAdd()
        {
            if (!IsEmployee())
                return RedirectToAction("Login", "Home");
            return View();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Handles the POST request to add a new farmer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FarmerAdd(FarmerAddViewModel model)
        {
            if (!IsEmployee())
                return RedirectToAction("Login", "Home");

            if (ModelState.IsValid)
            {
                bool farmerExists = _farmerRepo.Query().Any(f => f.Email == model.Email);
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

                await _farmerRepo.AddAsync(farmer);
                await _farmerRepo.SaveAsync();
                return RedirectToAction("FarmerProducts");
            }
            return View(model);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

    }
}
