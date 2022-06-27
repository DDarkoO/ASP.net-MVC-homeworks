using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Models.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaViewModel ToPizzaViewModel(this Pizza pizza)
        {
            return new PizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                //Price = SetPizzaPrice(pizza),
                Price = pizza.HasExtras ? pizza.Price + 10 : pizza.Price,
                PizzaSize = pizza.PizzaSize,
                HasExtras = pizza.HasExtras,
            };            
        }
        //public static decimal SetPizzaPrice(this Pizza pizza)
        //{
        //    if (pizza.HasExtras)
        //    {
        //        return pizza.Price += 10;
        //    }
        //    else return pizza.Price = pizza.Price;
        //}
    }
}
