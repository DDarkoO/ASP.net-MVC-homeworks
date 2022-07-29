using BurgerApp.DATA.ACCESS;
using BurgerApp.DATA.ACCESS.Implementations;
using BurgerApp.DOMAIN.Models;
using BurgerApp.SERVICES.Implementations;
using BurgerApp.SERVICES.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace BurgerApp.HELPERS
{
    public static class InjectionHelper
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Burger>, BurgerRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IBurgerService, BurgerService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
