using BurgerApp.DataAccess.Data;
using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BurgerApp.DataAccess.Repositories.Implementations;

public class LocationRepository : IRepository<Location>
{
    private BurgerAppDbContext _dbContext;

    public LocationRepository(BurgerAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Location entity)
    {
        _dbContext.Add(entity);
        _dbContext.SaveChanges();
    }

    public async Task Delete(int id)
    {
        var location = _dbContext.Locations.FirstOrDefaultAsync(x => x.Id == id);
        if (location is null) throw new Exception($"Unable to delete location {id}");

        _dbContext.Remove(location);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IAsyncEnumerable<Location>> GetAllAsync()
    {
        return await Task.FromResult(_dbContext.Locations.AsAsyncEnumerable());
    }

    public async Task<Location> GetByIdAsync(int id)
    {
        var location = await _dbContext.Locations.FirstOrDefaultAsync(x => x.Id == id);
        if (location is null) throw new Exception($"Location with id {id} was not found");

        return location;
    }

    public Task UpdateAsync(Location entity)
    {
        throw new NotImplementedException();
    }
}
