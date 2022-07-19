using BurgerApp.DOMAIN.Models;
using BurgerApp.VIEWMODELS.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.MAPPERS
{
    public static class OrderMapper
    {
        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                FullName = order.FullName,
                Address = order.Address,
                Location = order.Location,
                IsDelivered = order.IsDelivered,
                Burger = order.Burger
            };
        }

        public static Order ToOrder(this OrderViewModel orderViewModel)
        {
            return new Order
            {                
                FullName = orderViewModel.FullName,
                Address = orderViewModel.Address,
                Location = orderViewModel.Location,
                Burger = orderViewModel.Burger                
            };
        }
    }
}
