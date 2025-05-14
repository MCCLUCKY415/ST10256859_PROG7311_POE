// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - GitHub Copilot for assisting with the structure of the code.
// - ChatGPT for assisting me with finding and fixing errors in the code.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ST10256859_PROG7311_POE.DataBase
{

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

    // Generic repository interface for CRUD operations
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
        IQueryable<T> Query();
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
}
