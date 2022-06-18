using SEDC.PizzaApp.Models;

namespace SEDC.PizzaApp
{
    public static class StaticDb
    {
        public static List<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza()
            {
                Id = 1,
                Name = "Capri",
                Price = 300,
                IsOnPromotion = true,
            },
            new Pizza()
            {
                Id = 2,
                Name = "Pepperoni",
                Price = 400,
                IsOnPromotion = false
            },
            new Pizza()
            {
                Id = 3,
                Name = "Diavola",
                Price = 350,
                IsOnPromotion = true
            }
        };

        public static List<Order> Orders = new List<Order>
        {
            new Order()
            {
                Id = 1,
                OrderedPizzas = new List<Pizza>()
                {
                    Pizzas[0], 
                    Pizzas[1] 
                }
            },
            new Order()
            {
                Id = 2,
                OrderedPizzas = new List<Pizza>()
                {
                    Pizzas[2]
                }
            },
            new Order()
            {
                Id = 3,
                OrderedPizzas = new List<Pizza>()
                {
                    Pizzas[0],
                    Pizzas[1],
                    Pizzas[2]
                }
            },
        };
    }
}
