// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - GitHub Copilot for assisting with the structure of the code.
// - ChatGPT for assisting me with finding and fixing errors in the code.

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ST10256859_PROG7311_POE.DataBase
{
    // Generic repository implementation for CRUD operations
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Constructor with dependency injection
        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Gets all entities asynchronously
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        // Gets an entity by its ID asynchronously
        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        // Adds a new entity asynchronously
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        // Updates an existing entity
        public void Update(T entity) => _dbSet.Update(entity);

        // Deletes an entity
        public void Delete(T entity) => _dbSet.Remove(entity);

        // Saves changes to the database asynchronously
        public async Task SaveAsync() => await _context.SaveChangesAsync();

        // Returns an IQueryable for advanced queries
        public IQueryable<T> Query() => _dbSet.AsQueryable();
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

}
