using BurgerApp.DATA_ACCESS;
using BurgerApp.DATA_ACCESS.Implementations;
using BurgerApp.DOMAIN.Models;
using BurgerApp.SERVICES.Implementations;
using BurgerApp.SERVICES.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.HELPERS
{
    public static class InjectionHelper
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Burger>, BurgerRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IBurgerService, BurgerService>();
            services.AddTransient<IOrderService, OrderService>();
        }
    }
}
