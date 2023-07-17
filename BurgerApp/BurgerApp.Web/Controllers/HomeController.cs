using BurgerApp.Services.Abstraction;
using BurgerApp.ViewModels.HomeViewModels;
using BurgerApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;


namespace BurgerApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private IOrderService _orderService;
        private IBurgerService _burgerService;
        private ILocationService _locationService;
        public HomeController(IOrderService orderService, IBurgerService burgerService, ILocationService locationService)
        {
            _orderService = orderService;
            _burgerService = burgerService;
            _locationService = locationService;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            var orders = await _orderService.GetAllOrders();

            homeViewModel.OrderCount = await orders.CountAsync();
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}