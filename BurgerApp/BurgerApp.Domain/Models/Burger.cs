using System.ComponentModel.DataAnnotations;

namespace BurgerApp.Domain.Models;

public class Burger : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool IsVegeterian { get; set; }
    public bool IsVegan { get; set; }
    public bool HasFries { get; set; }

    public ICollection<OrderBurger> OrderBurgers { get; set; }
    public ICollection<LocationBurger> BurgerLocations { get; set; }
}
