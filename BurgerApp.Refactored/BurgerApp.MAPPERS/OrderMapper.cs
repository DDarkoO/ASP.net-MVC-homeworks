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
            double price = 0;
            foreach(var burgerOrder in order.BurgerOrders)
            {
                price += burgerOrder.Price;
            }

            return new OrderViewModel
            {
                Id = order.Id,
                FullName = order.FullName,
                Address = order.Address,
                Location = order.Location,
                IsDelivered = order.IsDelivered,
                Price = order.BurgerOrders.Sum(x => x.Price),
                BurgerOrders = order.BurgerOrders,
                BurgerId = order.BurgerId
            };
        }

        public static Order ToOrder(this OrderViewModel orderViewModel)
        {
            return new Order
            {                
                FullName = orderViewModel.FullName,
                Address = orderViewModel.Address,
                Location = orderViewModel.Location,
                BurgerOrders = new List<BurgerOrder>(),
                Id = orderViewModel.Id
            };
        }
    }
}
