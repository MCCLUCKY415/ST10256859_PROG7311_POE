 //Dhiren Ruthenavelu
 //ST10256859
 //Group 2

 //References:
 //- GitHub Copilot for assisting with the structure of the code.
 //- ChatGPT for assisting me with finding and fixing errors in the code.

using ST10256859_PROG7311_POE.DataBase;
using Microsoft.EntityFrameworkCore;

// Create a builder for the web application
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register the application's DbContext with SQLite as the database provider
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the generic repository for dependency injection
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Add support for controllers with views
builder.Services.AddControllersWithViews();

// Add support for Razor Pages
builder.Services.AddRazorPages();

// Add session support
builder.Services.AddSession();

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Use custom error handler and HSTS in production
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Enable serving static files (e.g., images, CSS, JS)
app.UseStaticFiles();

// Enable routing
app.UseRouting();

// Enable session state
app.UseSession();

// Enable authorization (if used)
app.UseAuthorization();

// Configure the default route for controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map Razor Pages endpoints
app.MapRazorPages();

// Run the application
app.Run();
