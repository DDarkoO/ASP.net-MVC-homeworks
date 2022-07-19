using BurgerApp.DOMAIN.Models;
using BurgerApp.VIEWMODELS.BurgerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.MAPPERS
{
    public static class BurgerMapper
    {
        public static BurgerViewModel ToBurgerViewModel(this Burger burger)
        {
            return new BurgerViewModel
            {
                Id = burger.Id,
                Name = burger.Name,
                Price = burger.Price,
                IsVegan = burger.IsVegan,
                IsVegetarian = burger.IsVegetarian,
                HasFries = burger.HasFries
            };
        }
 
        public static Burger ToBurger(this BurgerViewModel burgerViewModel)
        {
            return new Burger
            {
                Id = burgerViewModel.Id,
                Name = burgerViewModel.Name,
                HasFries = burgerViewModel.HasFries,
                IsVegetarian = burgerViewModel.IsVegetarian,
                IsVegan = burgerViewModel.IsVegan,
                Price = burgerViewModel.Price
            };
        }

        public static BurgerNamesDDViewModel ToBurgerNamesDDViewModel(this Burger burger)
        {
            return new BurgerNamesDDViewModel
            {
                Id = burger.Id,
                Name = burger.Name
            };
        }
    }
}
