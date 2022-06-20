using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Enums;

namespace SEDC.PizzaApp
{
    public static class StaticDb
    {

        public static List<Pizza> Pizzas = new List<Pizza> {
        new Pizza()
        {
            Id = 1,
            Name = "Capri",
            Price = 300,
            IsOnPromotion = true,
            HasExtras = true,
            PizzaSize = PizzaSize.normal
        },
        new Pizza()
        {
            Id = 2,
            Name = "Pepperoni",
            Price = 400,
            IsOnPromotion = false,
            HasExtras = false,
            PizzaSize = PizzaSize.family
        }
    };
        public static List<User> Users = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "Darko",
                LastName = "Dejanoski",
                PhoneNumber = "23543254325",
                Address = "Partizanska 44/12"
            },
            new User
            {
                Id = 2,
                FirstName = "Dejan",
                LastName = "Darkovski",
                PhoneNumber = "234234231234",
                Address = "Ilindenska 10/04"
            }
        };

        public static List<Order> Orders = new List<Order>
        {
            new Order
            {
                Id = 1,
                PizzaId = 1,
                UserId = 2,
                Pizza = Pizzas.First(),
                User = Users.First(x => x.Id ==2),
                PaymentMethod = PaymentMethod.Cash
            },
            new Order
            {
                Id = 2,
                PizzaId = 2,
                UserId = 1,
                Pizza = Pizzas.First(x => x.Id == 2),
                User = Users.First(x => x.Id == 1),
                PaymentMethod = PaymentMethod.Card
            }
        };
    }
}
