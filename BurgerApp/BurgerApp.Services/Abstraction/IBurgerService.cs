using BurgerApp.Domain.Models;

namespace BurgerApp.Services.Abstraction;

public interface IBurgerService
{
    Task<IAsyncEnumerable<Burger>> GetAllBurgers();
}
