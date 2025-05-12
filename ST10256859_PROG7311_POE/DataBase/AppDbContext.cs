using Microsoft.EntityFrameworkCore;
using ST10256859_PROG7311_POE.Models;

namespace ST10256859_PROG7311_POE.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
