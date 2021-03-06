using BurgerApp.Models.Domain;

namespace BurgerApp
{
    public static class StaticDb
    {
        public static int BurgerId = 5;
        public static int OrderId = 5;

        public static List<Burger> Burgers = new List<Burger>
        {
            new Burger()
            {
                Id = 1,
                Name = "Hamburger",
                Price = 150,
                IsVegan = false,
                IsVegetarian = false,
                HasFries = true
            },

            new Burger()
            {
                Id=2,
                Name = "Cheeseburger",
                Price = 170,
                IsVegan = false,
                IsVegetarian = false,
                HasFries = true
            },

            new Burger()
            {
                Id = 3,
                Name = "Greenburger",
                Price = 165,
                IsVegan = true,
                IsVegetarian = true,
                HasFries = false
            },

            new Burger()
            {
                Id = 4,
                Name = "Fitburger",
                Price = 180,
                IsVegan = true,
                IsVegetarian = true,
                HasFries = false
            },

            new Burger()
            {
                Id = 5,
                Name = "Happy burger",
                Price = 200,
                IsVegan = false,
                IsVegetarian = false,
                HasFries = true
            }
        };

        public static List<Order> Orders = new List<Order>
        {
            new Order()
            {
                Id = 1,
                FullName = "Michael Jordan",
                Address = "Partizanska 44-1/22",
                IsDelivered = false,
                Burger = Burgers.First(x => x.Id == 1),
                BurgerId = 1,
                Location = "Fontana Park",
                PaymentMethod = Models.Enums.PaymentMethod.Cash
            },

            new Order()
            {
                Id = 2,
                FullName = "Rafael Nadal",
                Address = "Ilindenska 25-2/15",
                IsDelivered = true,
                Burger = Burgers.First(x => x.Id == 2),
                BurgerId = 2,
                Location = "Vodno - Mileniumski Krst",
                PaymentMethod = Models.Enums.PaymentMethod.Card
            },

            new Order()
            {
                Id = 3,
                FullName = "Charles Leclerc",
                Address = "Ferrari St, Maranello 1-A",
                IsDelivered = false,
                Burger = Burgers.First(x => x.Id == 3),
                BurgerId = 3,
                Location = "Maranello 2-C",
                PaymentMethod = Models.Enums.PaymentMethod.Cash
            },

            new Order()
            {
                Id = 4,
                FullName = "Carlos Sainz",
                Address = "Ferrari St, Maranello 3.B",
                IsDelivered = true,
                Burger = Burgers.First(x => x.Id == 4),
                BurgerId = 4,
                Location = "Pit-stop No.1",
                PaymentMethod = Models.Enums.PaymentMethod.Card
            },

            new Order()
            {
                Id = 5,
                FullName = "Kire Lazarov",
                Address = "Champions boulevard 3/5a, Skopje ",
                IsDelivered = false,
                Burger = Burgers.First(x => x.Id == 5),
                BurgerId = 5,
                Location = "SS Rasadnik, lozha",
                PaymentMethod = Models.Enums.PaymentMethod.Cash
            },

        };
    }
}
