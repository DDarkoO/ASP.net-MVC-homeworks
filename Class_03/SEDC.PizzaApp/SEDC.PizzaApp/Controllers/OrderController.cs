using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            List<Order> ordersDb = StaticDb.Orders;

            #region commented out class code
            //List<OrderDetailsViewModel> orderViewModels = ordersDb.Select(x => new OrderDetailsViewModel
            //{
            //    PaymentMethod = x.PaymentMethod,
            //    PizzaName = x.Pizza.Name,
            //    Price = x.Pizza.Price + 50,
            //    UserFullName = $"{x.User.FirstName} {x.User.LastName}"
            //}).ToList();


            // --------------- ALTERNATIVE LONGER WAY
            //List<OrderDetailsViewModel> viewModels = new List<OrderDetailsViewModel>();
            //foreach (Order order in ordersDb)
            //{
            //    viewModels.Add(new OrderDetailsViewModel
            //    {
            //        PaymentMethod = order.PaymentMethod,
            //        PizzaName = order.Pizza.Name,
            //        Price = order.Pizza.Price + 50,
            //        UserFullName = $"{order.User.FirstName} {order.User.LastName}"
            //    });

            //}
            #endregion

            List<OrderDetailsViewModel> orderViewModels = ordersDb.Select(x => OrderMapper.ToOrderDetailsViewModel(x)).ToList();

            //return View(ordersDb);
            return View(orderViewModels);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new EmptyResult();
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (orderDb == null)
            {
                return new EmptyResult();
            }
            #region commented out class code
            //map from domain to view model (view model e customized view shto sodrzhi striktno samo podatoci shto ni trebaat)

            //OrderDetailsViewModel orderDetailsViewModel = new OrderDetailsViewModel
            //{
            //    PaymentMethod = orderDb.PaymentMethod,
            //    PizzaName = orderDb.Pizza.Name,
            //    Price = orderDb.Pizza.Price + 50,
            //    UserFullName = $"{orderDb.User.FirstName} {orderDb.User.LastName}"
            //};
            #endregion

            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.ToOrderDetailsViewModel(orderDb);

            return View(orderDetailsViewModel);

            //return View(orderDb);
        }
    }
}
