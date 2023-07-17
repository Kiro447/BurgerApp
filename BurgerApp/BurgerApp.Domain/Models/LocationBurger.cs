namespace BurgerApp.Domain.Models;

public class LocationBurger
{
    public int LocationId { get; set; }
    public Location Location { get; set; }
    public int BurgerId { get; set; }
    public Burger Burger { get; set; }
}
