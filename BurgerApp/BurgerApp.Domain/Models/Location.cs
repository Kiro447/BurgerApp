﻿using System.ComponentModel.DataAnnotations;

namespace BurgerApp.Domain.Models;

public class Location : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public TimeSpan OpensAt { get; set; }

    public TimeSpan ClosesAt { get; set; }

    public ICollection<LocationBurger> LocationBurgers { get; set; } // nav prop m2m indirect relationship
}
