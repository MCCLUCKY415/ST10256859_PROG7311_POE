// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - GitHub Copilot for assisting with the structure of the code.
// - ChatGPT for assisting me with finding and fixing errors in the code.

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10256859_PROG7311_POE.DataBase;
using ST10256859_PROG7311_POE.Models;
using ST10256859_PROG7311_POE.ViewModels;

namespace ST10256859_PROG7311_POE.Controllers
{
    // Handles home page and authentication actions
    public class HomeController : Controller
    {
        // Logger and repositories for Farmer and Employee
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Farmer> _farmerRepo;
        private readonly IRepository<Employee> _employeeRepo;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Constructor with dependency injection
        public HomeController(
            ILogger<HomeController> logger,
            IRepository<Farmer> farmerRepo,
            IRepository<Employee> employeeRepo)
        {
            _logger = logger;
            _farmerRepo = farmerRepo;
            _employeeRepo = employeeRepo;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // GET: Login page
        public IActionResult Login()
        {
            return View();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // POST: Handles login for Farmer and Employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var farmer = _farmerRepo.Query()
                    .FirstOrDefault(f => f.Email == model.Email && f.Password == model.Password);

                if (farmer != null)
                {
                    HttpContext.Session.SetString("UserRole", "Farmer");
                    HttpContext.Session.SetString("UserID", farmer.FarmerID.ToString());
                    HttpContext.Session.SetString("UserName", farmer.FirstName + " " + farmer.LastName);
                    return RedirectToAction("FarmerProfile", "Farmer");
                }

                var employee = _employeeRepo.Query()
                    .FirstOrDefault(e => e.Email == model.Email && e.Password == model.Password);

                if (employee != null)
                {
                    HttpContext.Session.SetString("UserRole", "Employee");
                    HttpContext.Session.SetString("UserID", employee.EmployeeID.ToString());
                    HttpContext.Session.SetString("UserName", employee.FirstName + " " + employee.LastName);
                    return RedirectToAction("FarmerProducts", "Employee");
                }

                ModelState.AddModelError("", "Email or password is incorrect or account doesn't exist.");
            }

            return View(model);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // GET: SignUp page
        public IActionResult SignUp()
        {
            return View();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // POST: Handles sign up for new Employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool farmerExists = _farmerRepo.Query().Any(f => f.Email == model.Email);
                bool employeeExists = _employeeRepo.Query().Any(e => e.Email == model.Email);

                if (farmerExists || employeeExists)
                {
                    ModelState.AddModelError("", "Email already exists.");
                    return View(model);
                }

                var employee = new Employee
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    Email = model.Email,
                    Password = model.Password
                };
                await _employeeRepo.AddAsync(employee);
                await _employeeRepo.SaveAsync();

                return RedirectToAction("Login");
            }

            return View(model);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // POST: Logs out the current user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // GET: Home page, shows all farmers
        public async Task<IActionResult> Index()
        {
            var farmers = await _farmerRepo.GetAllAsync();
            return View(farmers);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Handles errors
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
