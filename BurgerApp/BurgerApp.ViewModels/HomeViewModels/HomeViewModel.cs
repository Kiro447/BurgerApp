namespace BurgerApp.ViewModels.HomeViewModels;

public class HomeViewModel
{
    public string PopularBurger { get; set; }
    public int OrderCount { get; set; }
    public decimal AveragePrice { get; set; }
    public List<string> Locations { get; set; }

}
