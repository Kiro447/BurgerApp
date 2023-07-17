using Bogus;
using BurgerApp.DataAccess.Data;
using BurgerApp.Domain.Models;

namespace BurgerApp.DataAccess.DataSeed;

public class BurgerAppDataSeed
{
    private readonly BurgerAppDbContext _dbContext;

    public BurgerAppDataSeed(BurgerAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SeedData()
    {
        // Fake Burgers
        var burgerFaker = new Faker<Burger>()
            .RuleFor(b => b.Name, f => f.Commerce.ProductName())
            .RuleFor(b => b.Price, f => f.Finance.Amount(1, 100))
            .RuleFor(b => b.IsVegeterian, f => f.Random.Bool())
            .RuleFor(b => b.IsVegan, f => f.Random.Bool())
            .RuleFor(b => b.HasFries, f => f.Random.Bool());

        List<Burger> burgers = burgerFaker.Generate(10);

        // Fake Locations
        var locationFaker = new Faker<Location>()
            .RuleFor(l => l.Name, f => f.Address.City())
            .RuleFor(l => l.Address, f => f.Address.StreetAddress())
            .RuleFor(l => l.OpensAt, f => TimeSpan.FromHours(f.Random.Int(0, 23)))
            .RuleFor(l => l.ClosesAt, f => TimeSpan.FromHours(f.Random.Int(0, 23)));

        List<Location> locations = locationFaker.Generate(5);

        // Fake Orders
        var orderFaker = new Faker<Order>()
            .RuleFor(o => o.FullName, f => f.Name.FullName())
            .RuleFor(o => o.Address, f => f.Address.FullAddress())
            .RuleFor(o => o.IsDelivered, f => f.Random.Bool())
            .RuleFor(o => o.Location, f => f.PickRandom(locations));

        List<Order> orders = orderFaker.Generate(3);


        foreach (var burger in burgers)
        {
            _dbContext.Burgers.Add(burger);
        }

        foreach (var location in locations)
        {
            _dbContext.Locations.Add(location);
        }

        foreach (var order in orders)
        {
            _dbContext.Orders.Add(order);
        }

        _dbContext.SaveChanges();
    }
}
