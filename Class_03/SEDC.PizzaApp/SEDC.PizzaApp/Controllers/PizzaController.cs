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
            List<Pizza> dbPizzas = StaticDb.Pizzas;

            List<PizzaViewModel> pizzaViewModels = new();
            
            foreach (Pizza pizza in dbPizzas)
            {
                PizzaViewModel pizzaViewModel = PizzaMapper.ToPizzaViewModel(pizza);
                pizzaViewModels.Add(pizzaViewModel);
            }

            return View(pizzaViewModels);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new EmptyResult();
            }

            PizzaViewModel pizza = PizzaMapper.ToPizzaViewModel(StaticDb.Pizzas.FirstOrDefault(x => x.Id == id));

            if (pizza == null)
            {
                return new EmptyResult();
            }

            return View(pizza);

            //Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);

            //if (pizza == null)
            //{
            //    return RedirectToAction("Error");
            //}

            //return View(pizza);
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult TestPizza()
        {
            Pizza pizza = StaticDb.Pizzas[0];

            PizzaViewModel testPizza = Pizza.PizzaToPizzaViewModel(pizza);

            return View(testPizza);
        }

    }
}
