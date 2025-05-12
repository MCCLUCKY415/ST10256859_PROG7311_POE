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
                var user = _context.Users
                    .FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    // Set session or cookie for the logged-in user
                    HttpContext.Session.SetString("UserID", user.Id.ToString());

                    return RedirectToAction("Index", "Home");  // Redirect to home or dashboard
                }

                ModelState.AddModelError("", "Invalid username or password.");
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
                var userExists = _context.Users
                    .FirstOrDefault(u => u.Email == model.Email);

                if (userExists != null)
                {
                    ModelState.AddModelError("", "Username already exists.");
                    return View(model);
                }

                var user = new User
                {
                    Email = model.Email,
                    Password = model.Password,
                    Role = model.Role,
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(model);
        }


        public IActionResult Index()
        {
            return View();
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
