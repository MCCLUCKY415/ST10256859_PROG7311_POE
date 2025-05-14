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
        private readonly IRepository<Farmer> _farmerRepo;
        private readonly IRepository<Employee> _employeeRepo;

        public HomeController(
            ILogger<HomeController> logger,
            IRepository<Farmer> farmerRepo,
            IRepository<Employee> employeeRepo)
        {
            _logger = logger;
            _farmerRepo = farmerRepo;
            _employeeRepo = employeeRepo;
        }


        // GET: Login
        public IActionResult Login()
        {
            return View();
        }


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
                    return RedirectToAction("Index", "Home");
                }

                var employee = _employeeRepo.Query()
                    .FirstOrDefault(e => e.Email == model.Email && e.Password == model.Password);

                if (employee != null)
                {
                    HttpContext.Session.SetString("UserRole", "Employee");
                    HttpContext.Session.SetString("UserID", employee.EmployeeID.ToString());
                    HttpContext.Session.SetString("UserName", employee.FirstName + " " + employee.LastName);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Email or password is incorrect or account doesn't exist.");
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }


        public async Task<IActionResult> Index()
        {
            var farmers = await _farmerRepo.GetAllAsync();
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
