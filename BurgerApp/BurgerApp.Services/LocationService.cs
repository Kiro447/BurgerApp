using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;
using BurgerApp.Services.Abstraction;

namespace BurgerApp.Services;

public class LocationService : ILocationService
{
    private IRepository<Location> _locationRepository;

    public LocationService(IRepository<Location> locationRepository)
    {
        _locationRepository = locationRepository;
    }
}
