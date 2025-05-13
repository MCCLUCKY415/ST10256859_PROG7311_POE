using System.Collections.Generic;
using System.Threading.Tasks;

namespace ST10256859_PROG7311_POE.DataBase
{
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
}
