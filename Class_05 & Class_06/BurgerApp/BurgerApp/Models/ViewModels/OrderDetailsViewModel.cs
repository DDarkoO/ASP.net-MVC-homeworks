﻿using BurgerApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BurgerApp.Models.ViewModels
{
    public class OrderDetailsViewModel
    {
        [Display(Name = "Customer name")]
        public string FullName { get; set; }
        [Display(Name = "Burger")]
        public string BurgerName { get; set; }
        [Display(Name = "Delivery location")]
        public string Location { get; set; }
        public double Price { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int Id { get; set; }
    }
}
