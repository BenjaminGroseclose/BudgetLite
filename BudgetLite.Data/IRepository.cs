using BudgetLite.Data.Models;

namespace BudgetLite.Data
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> Get(int id);
        IEnumerable<T> GetAll();
        Task<T> Update(int id, T entity);
        Task<bool> Delete(int id);
        Task<T> Insert(T entity);
    }
}
