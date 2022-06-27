using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult GetPizzas()
        {
            List<PizzaViewModel> dbPizzas = StaticDb.Pizzas.Select(x => x.ToPizzaViewModel()).ToList();
            return View(dbPizzas);
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Error");
            }

            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if(pizza == null)
            {
                //return RedirectToAction("Error");
                return View("ResourceNotFound");
            }

            PizzaViewModel pizzaViewModel = PizzaMapper.ToPizzaViewModel(StaticDb.Pizzas.FirstOrDefault(x => x.Id == id));
            if (pizzaViewModel == null)
            {
                //return RedirectToAction("Error");
                return View("ResourceNotFound");
            }

            ViewData["Promotion"] = pizzaViewModel.IsOnPromotion;
            Console.WriteLine(ViewData["Promotion"].GetType());

            ViewBag.IsOnPromotion = pizzaViewModel.IsOnPromotion;

            return View(pizzaViewModel);
            //return View(pizza);
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
