using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;
using BurgerApp.Services.Abstraction;

namespace BurgerApp.Services;

public class BurgerService : IBurgerService
{
    private IRepository<Burger> _burgerRepository;

    public BurgerService(IRepository<Burger> burgerRepository)
    {
        _burgerRepository = burgerRepository;
    }

    public async Task<IAsyncEnumerable<Burger>> GetAllBurgers()
    {
        return await _burgerRepository.GetAllAsync();
    }
}
