using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;

namespace SEDC.PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        [Route("ListOrders")]
        public IActionResult ListOrders()
        {
            return View();
        }

        
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return new EmptyResult();
            }

            Order order = StaticDb.Orders.FirstOrDefault(x => x.Id == id);

            if(order == null)
            {
                return new EmptyResult();
            }

            return View(order);
        }

        public IActionResult JsonData()
        {
            Pizza pizza = new Pizza(1, "Diavola", 300, true);

            return new JsonResult(pizza);            
        }

        public IActionResult RedirectToHome()
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
