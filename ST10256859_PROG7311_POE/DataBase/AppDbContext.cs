using Microsoft.EntityFrameworkCore;

namespace ST10256859_PROG7311_POE.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
