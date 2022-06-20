using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Models.Mappers
{
    public class PizzaMapper
    {
        public static PizzaViewModel ToPizzaViewModel(Pizza pizza)
        {
            return new PizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = SetPizzaPrice(pizza),
                PizzaSize = pizza.PizzaSize,
                HasExtras = pizza.HasExtras,
            };

            
        }
        public static decimal SetPizzaPrice(Pizza pizza)
        {
            if (pizza.HasExtras)
            {
                return pizza.Price += 10;
            }
            else return pizza.Price = pizza.Price;
        }
    }
}
