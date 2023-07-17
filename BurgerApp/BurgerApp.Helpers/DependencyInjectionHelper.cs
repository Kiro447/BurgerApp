using BurgerApp.DataAccess.Data;
using BurgerApp.DataAccess.Repositories.Implementations;
using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;
using BurgerApp.Services;
using BurgerApp.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BurgerApp.Helpers
{

    public static class DependencyInjectionHelper
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IBurgerService, BurgerService>();
            services.AddTransient<ILocationService, LocationService>();

        }
        public static void InjectRepositories(this IServiceCollection services)
        {
            // entity framework
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<Burger>, BurgerRepository>();
            services.AddTransient<IRepository<Location>, LocationRepository>();
        }
        public static void InjectDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BurgerAppDbContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
