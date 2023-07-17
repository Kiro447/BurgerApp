using BurgerApp.Domain.Models;

namespace BurgerApp.DataAccess.Repositories.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    void Add(T entity);
    Task UpdateAsync(T entity);
    Task Delete(int id);
    Task<T> GetByIdAsync(int id);
    Task<ICollection<T>> GetAllAsync();

}
