using BurgerApp.DATA_ACCESS;
using BurgerApp.DOMAIN.Models;
using BurgerApp.MAPPERS;
using BurgerApp.SERVICES.Interfaces;
using BurgerApp.VIEWMODELS.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.SERVICES.Implementations
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;
        private IRepository<Burger> _burgerRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<Burger> burgerRepository)
        {
            _orderRepository = orderRepository;
            _burgerRepository = burgerRepository;
        }

        public void AddOrder(OrderViewModel orderViewModel)
        {
            if (string.IsNullOrEmpty(orderViewModel.Address) || string.IsNullOrEmpty(orderViewModel.Location))
            {
                throw new Exception("You must input an address and location!");
            }

            Order newOrder = orderViewModel.ToOrder();
            newOrder.IsDelivered = false;
            //newOrder.Burger = _orderRepository.
            int newOrderId = _orderRepository.Insert(newOrder);
            if (newOrderId <= 0)
            {
                throw new Exception("Critical error, come back tomorrow.");
            }

        }

        public void DeleteOrder(int id)
        {
            if (id <= 0 || id == null)
            {
                throw new Exception("Order not found.");
            }

            Order orderToDelete = _orderRepository.GetById(id);
            if(orderToDelete == null)
            {
                throw new Exception("The order was not found.");
            }

            _orderRepository.DeleteById(id);

        }

        public void EditOrder(OrderViewModel orderViewModel)
        {
            if(orderViewModel == null)
            {
                throw new Exception("The order was not found");
            }
                        
            Order orderToEdit = _orderRepository.GetById(orderViewModel.Id);

            orderToEdit.IsDelivered = orderViewModel.IsDelivered;
            orderToEdit.Address = orderViewModel.Address;
            orderToEdit.Location = orderViewModel.Location;
            orderToEdit.Id = orderViewModel.Id;
            orderToEdit.BurgerOrders = orderViewModel.BurgerOrders;

            _orderRepository.Edit(orderToEdit);
        }

        public List<OrderViewModel> GetAllOrders()
        {
            List<Order> orders = _orderRepository.GetAll();
            List<OrderViewModel> allOrders = orders.Select(x => x.ToOrderViewModel()).ToList();
            return allOrders;
        }

        OrderViewModel IOrderService.GetOrderById(int id)
        {
            if(id == null)
            {
                throw new Exception("Order not found.");
            }

            OrderViewModel orderViewModel = _orderRepository.GetById(id).ToOrderViewModel();
            if(orderViewModel == null)
            {
                throw new Exception("Order not found.");
            }

            return orderViewModel;
        }

        OrderViewModel IOrderService.ImportBurgerToOrderViewModel(OrderViewModel orderViewModel)
        {
            OrderViewModel updatedOrderViewModel = new()
            {
                FullName = orderViewModel.FullName,
                Address = orderViewModel.Address,
                Location = orderViewModel.Location,
                BurgerOrders = orderViewModel.BurgerOrders
            };

            //foreach (var burgerOrder in orderViewModel.BurgerOrders)
            //{
            //    Burger burger = _burgerRepository.GetById(burgerOrder.Burger.Id);
            //    updatedOrderViewModel.BurgerOrders.Add(burger);
            //}

            return updatedOrderViewModel;
        }
    }
}
