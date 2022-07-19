using BurgerApp.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DATA_ACCESS
{

    public static class StaticDb
    {

        static StaticDb()
        {
            BurgerId = 5;
            OrderId = 5;
            BurgerOrderId = 5;

            Burgers = new List<Burger>
            {
                new Burger()
                {
                    Id = 1,
                    Name = "Hamburger",
                    Price = 150,
                    IsVegan = false,
                    IsVegetarian = false,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder>
                    {

                    }
                },

                new Burger()
                {
                    Id = 2,
                    Name = "Cheeseburger",
                    Price = 170,
                    IsVegan = false,
                    IsVegetarian = false,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder>
                    {

                    }
                },

                new Burger()
                {
                    Id = 3,
                    Name = "Greenburger",
                    Price = 165,
                    IsVegan = true,
                    IsVegetarian = true,
                    HasFries = false,
                    BurgerOrders = new List<BurgerOrder>
                    {

                    }
                },

                new Burger()
                {
                    Id = 4,
                    Name = "Fitburger",
                    Price = 180,
                    IsVegan = true,
                    IsVegetarian = true,
                    HasFries = false,
                    BurgerOrders = new List<BurgerOrder>
                    {

                    }
                },

                new Burger()
                {
                    Id = 5,
                    Name = "Happy burger",
                    Price = 200,
                    IsVegan = false,
                    IsVegetarian = false,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder>
                    {

                    }
                }
            };

            Orders = new List<Order>
            {
                new Order()
                {
                    Id = 1,
                    FullName = "Michael Jordan",
                    Address = "Partizanska 44-1/22",
                    IsDelivered = false,
                    Location = "Fontana Park",
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id=1,
                            Burger = Burgers.First(x => x.Id == 1),
                            BurgerId = Burgers.First(x => x.Id == 1).Id,
                            Price = Burgers.First(x => x.Id == 1).Price,
                            OrderId = 1
                        }
                    }
                },

                new Order()
                {
                    Id = 2,
                    FullName = "Rafael Nadal",
                    Address = "Ilindenska 25-2/15",
                    IsDelivered = true,                    
                    Location = "Vodno - Mileniumski Krst",
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 2,
                            Burger = Burgers.First(x => x.Id == 2),
                            BurgerId = Burgers.First(x => x.Id == 2).Id,
                            OrderId = 2,
                            Price = Burgers.First(x => x.Id == 2).Price
                        }
                    }
                },

                new Order()
                {
                    Id = 3,
                    FullName = "Charles Leclerc",
                    Address = "Ferrari St, Maranello 1-A",
                    IsDelivered = false,                    
                    Location = "Maranello 2-C",
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 3,
                            Burger = Burgers.First(x => x.Id == 3),
                            BurgerId = Burgers.First(x => x.Id == 3).Id,
                            OrderId = 3,
                            Price = Burgers.First(x => x.Id == 3).Price
                        }
                    }
                },

                new Order()
                {
                    Id = 4,
                    FullName = "Carlos Sainz",
                    Address = "Ferrari St, Maranello 3.B",
                    IsDelivered = true,                    
                    Location = "Pit-stop No.1",
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 4,
                            Burger = Burgers.First(x => x.Id == 4),
                            BurgerId = Burgers.First(x => x.Id == 4).Id,
                            OrderId = 4,
                            Price = Burgers.First(x => x.Id == 4).Price
                        }
                    }
                },

                new Order()
                {
                    Id = 5,
                    FullName = "Kire Lazarov",
                    Address = "Champions boulevard 3/5a, Skopje ",
                    IsDelivered = false,
                    Location = "SS Rasadnik, lozha",
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 5,
                            Burger = Burgers.First(x => x.Id == 5),
                            BurgerId = Burgers.First(x => x.Id == 5).Id,
                            OrderId = 5,
                            Price = Burgers.First(x => x.Id == 5).Price
                        }
                    }
                },

            };
        }
        public static int BurgerId { get; set; }
        public static int OrderId { get; set; }
        public static int BurgerOrderId { get; set; }
        public static List<Burger> Burgers { get; set; }
        public static List<Order> Orders { get; set; }
    }

}


