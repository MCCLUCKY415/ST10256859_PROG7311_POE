using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10256859_PROG7311_POE.DataBase;
using ST10256859_PROG7311_POE.Models;
using ST10256859_PROG7311_POE.ViewModels;

namespace ST10256859_PROG7311_POE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        // GET: Login
        public IActionResult Login()
        {
            return View();
        }


        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Try to find the user as a Farmer
                var farmer = _context.Farmers
                    .FirstOrDefault(f => f.Email == model.Email && f.Password == model.Password);

                if (farmer != null)
                {
                    HttpContext.Session.SetString("UserRole", "Farmer");
                    HttpContext.Session.SetString("UserID", farmer.FarmerID.ToString());
                    HttpContext.Session.SetString("UserName", farmer.FirstName + " " + farmer.LastName);
                    return RedirectToAction("Index", "Home");
                }

                // Try to find the user as an Employee
                var employee = _context.Employees
                    .FirstOrDefault(e => e.Email == model.Email && e.Password == model.Password);

                if (employee != null)
                {
                    HttpContext.Session.SetString("UserRole", "Employee");
                    HttpContext.Session.SetString("UserID", employee.EmployeeID.ToString());
                    HttpContext.Session.SetString("UserName", employee.FirstName + " " + employee.LastName);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid email or password.");
            }

            return View(model);
        }



        // GET: SignUp
        public IActionResult SignUp()
        {
            return View();
        }


        // POST: SignUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the email already exists in either table
                bool farmerExists = _context.Farmers.Any(f => f.Email == model.Email);
                bool employeeExists = _context.Employees.Any(e => e.Email == model.Email);

                if (farmerExists || employeeExists)
                {
                    ModelState.AddModelError("", "Email already exists.");
                    return View(model);
                }

                // Always create an Employee
                var employee = new Employee
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    Email = model.Email,
                    Password = model.Password
                };
                _context.Employees.Add(employee);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }


        public IActionResult Index()
        {
            var farmers = _context.Farmers.ToList();
            return View(farmers);
        }


        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
