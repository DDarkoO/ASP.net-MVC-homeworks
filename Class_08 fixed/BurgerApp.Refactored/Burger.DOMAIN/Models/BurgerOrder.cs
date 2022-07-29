﻿using BurgerApp.DOMAIN.Enums;

namespace BurgerApp.DOMAIN.Models
{
    public class BurgerOrder
    {        
        public int Id { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Burger Burger { get; set; }
        public int BurgerId { get; set; }
        public BurgerSize BurgerSize { get; set; }
        public int NumberOfBurgers { get; set; }
        public double Price => Burger.Price * NumberOfBurgers;

    }
}
