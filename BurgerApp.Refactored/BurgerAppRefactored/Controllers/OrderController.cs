using BurgerApp.SERVICES.Interfaces;
using BurgerApp.VIEWMODELS.BurgerViewModels;
using BurgerApp.VIEWMODELS.OrderViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerAppRefactored.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private IBurgerService _burgerService;
        public OrderController(IOrderService orderService, IBurgerService burgerService)
        {
            _orderService = orderService;
            _burgerService = burgerService;
        }

        public IActionResult AllOrders()
        {
            List<OrderViewModel> allOrderViewModels = _orderService.GetAllOrders();
            return View(allOrderViewModels);
        }

        public IActionResult AddOrder()
        {
            ViewBag.ListOfBurgers = _burgerService.GetBurgerNamesForDD();

            OrderViewModel orderViewModel = new OrderViewModel();
            return View(orderViewModel);
        }
        [HttpPost]
        public IActionResult AddOrderPost(OrderViewModel orderViewModel)
        {
            OrderViewModel updatedOrderViewModel = _orderService.ImportBurgerToOrderViewModel(orderViewModel);

            try
            {
                _orderService.AddOrder(updatedOrderViewModel);
                return RedirectToAction("AllOrders");
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        public IActionResult DeleteOrder(int? id)
        {
            if (id == null || id <= 0)
            {
                return View("ResourceNotFound");
            }

            try
            {
                OrderViewModel orderViewModel = _orderService.GetOrderById(id.Value);
                return View(orderViewModel);
            }
            catch (Exception e)
            {
                return View("ResourceNotFound");
            }

        }

        public IActionResult ConfirmDelete(int? id)
        {
            if (id == null || id <= 0)
            {
                return View("ResourceNotFound");
            }

            _orderService.DeleteOrder(id.Value);
            return RedirectToAction("AllOrders");
        }

        public IActionResult EditOrder(int? id)
        {
            if (id == null || id <= 0)
            {
                return View("ResourceNotFound");
            }

            ViewBag.ListOfBurgers = _burgerService.GetBurgerNamesForDD();

            try
            {
                OrderViewModel orderViewModel = _orderService.GetOrderById(id.Value);
                return View(orderViewModel);
            }
            catch (Exception e)
            {
                return View("ResourceNotFound");
            }
        }

        public IActionResult EditOrderPost(OrderViewModel orderViewModel)
        {
            if (orderViewModel == null || string.IsNullOrEmpty(orderViewModel.FullName) || string.IsNullOrEmpty(orderViewModel.Address) || string.IsNullOrEmpty(orderViewModel.Location))
            {
                return View("You haven't filled all the necessary data during editing of the existing order. Please try again.");
            }

            _orderService.EditOrder(orderViewModel);

            return RedirectToAction("AllOrders");
        }
    }
}