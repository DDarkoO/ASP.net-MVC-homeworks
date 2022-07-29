using BurgerApp.DATA.ACCESS;
using BurgerApp.DATA.ACCESS.Implementations;
using BurgerApp.DOMAIN.Models;
using BurgerApp.MAPPERS;
using BurgerApp.SERVICES.Interfaces;
using BurgerApp.VIEWMODELS.OrderViewModels;

namespace BurgerApp.SERVICES.Implementations
{
    public class OrderService : IOrderService
    {

        private IRepository<Order> _orderRepository;
        private IRepository<Burger> _burgerRepository;
        private IRepository<User> _userRepository;

        public OrderService()
        {
            _orderRepository = new OrderRepository();
            _burgerRepository = new BurgerRepository();
            _userRepository = new UserRepository();
        }


        public void AddOrder(OrderViewModel orderViewModel)
        {
            if(orderViewModel == null)
            {
                throw new ArgumentNullException(nameof(orderViewModel));
            }
            User user = _userRepository.GetById(orderViewModel.UserId);

            Order order = orderViewModel.ToOrder();
            order.User = user;

            _orderRepository.Add(order);

        }

        public void EditOrder(OrderViewModel orderViewModel)
        {
            if (orderViewModel == null)
            {
                throw new ArgumentNullException(nameof(orderViewModel));
            }

            Order order = orderViewModel.ToOrder();
            if(order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            _orderRepository.Edit(order);
        }

        public List<OrderDetailsViewModel> GetAllOrders()
        {
            List<OrderDetailsViewModel> orderDetailsViewModels = _orderRepository.GetAll().Select(x => x.ToOrderDetailsViewModel()).ToList();
            return orderDetailsViewModels;
        }

        public OrderDetailsViewModel GetOrderById(int id)
        {
            if(id == 0 || id <= 0)
            {
                throw new Exception("Order was not found");
            }

            return _orderRepository.GetById(id).ToOrderDetailsViewModel();
            
        }



        public OrderViewModel AddBurgerNamesAndNumberToOrderViewModel(OrderViewModel orderViewModel)
        {
            if(orderViewModel == null)
            {
                throw new Exception("OrderViewModel is faulty!");
            }

            for(int i = 0; i < orderViewModel.BurgerNames.Count; i++)
            {
                BurgerOrder burgerOrder = new BurgerOrder()
                {                    
                    BurgerId = _burgerRepository.GetAll().FirstOrDefault(x => x.Name == orderViewModel.BurgerNames[i]).Id,
                    Burger = _burgerRepository.GetById(_burgerRepository.GetAll().FirstOrDefault(x => x.Name == orderViewModel.BurgerNames[i]).Id),
                    BurgerSize = orderViewModel.BurgerSizes[i],
                    NumberOfBurgers = 1
                };
                orderViewModel.BurgerOrders.Add(burgerOrder);
            }

            return orderViewModel;
        }

        OrderViewModel IOrderService.GetOrderByIdToViewModel(int id)
        {
            if (id == 0 || id <= 0)
            {
                throw new Exception("Order was not found");
            }

            return _orderRepository.GetById(id).ToOrderViewModel();

        }

        OrderViewModel IOrderService.RemoveBurgerOrdersFromViewModel(OrderViewModel orderViewModel)
        {
            orderViewModel.BurgerOrders.RemoveRange(
                orderViewModel.NumberOfBurgers, orderViewModel.BurgerOrders.Count - orderViewModel.NumberOfBurgers);
            return orderViewModel;
        }

        void IOrderService.DeleteOrderById(int id)
        {
            if(id == 0 || id <= 0)
            {
                throw new Exception("Order was not found");
            }
            Order order = _orderRepository.GetById(id);
            if(order == null)
            {
                throw new Exception("The order was not found");
            }

            _orderRepository.DeleteById(id);
        }
                
    }
}
