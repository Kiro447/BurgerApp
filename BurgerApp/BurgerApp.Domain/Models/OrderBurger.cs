namespace BurgerApp.Domain.Models;

public class OrderBurger
{
    public int Id { get; set; }
    public int BurgerId { get; set; }
    public Burger Burger { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
}