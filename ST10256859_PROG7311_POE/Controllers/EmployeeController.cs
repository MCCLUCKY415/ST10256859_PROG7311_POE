using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10256859_PROG7311_POE.DataBase;
using ST10256859_PROG7311_POE.ViewModels;

namespace ST10256859_PROG7311_POE.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult FarmerProducts(int? farmerId, string category, DateTime? startDate, DateTime? endDate)
        {
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
    }
}
