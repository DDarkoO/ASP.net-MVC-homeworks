using BurgerApp.VIEWMODELS.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.SERVICES.Interfaces
{
    public interface IOrderService
    {
        List<OrderViewModel> GetAllOrders();
        void AddOrder(OrderViewModel orderViewModel);
        void EditOrder(OrderViewModel orderViewModel);
        void DeleteOrder(int id);
        OrderViewModel ImportBurgerToOrderViewModel(OrderViewModel orderViewModel);
        OrderViewModel GetOrderById(int id);
    }
}
