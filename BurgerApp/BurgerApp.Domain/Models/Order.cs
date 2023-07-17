using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace BurgerApp.Domain.Models;

public class Order : BaseEntity
{
    public string FullName { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public bool IsDelivered { get; set; }

    public ICollection<OrderBurger> OrderBurgers { get; set; } // nav property m2m indirect relationship

    public Location Location { get; set; }
}
