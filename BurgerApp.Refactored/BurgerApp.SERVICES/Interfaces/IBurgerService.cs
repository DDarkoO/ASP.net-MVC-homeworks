using BurgerApp.VIEWMODELS.BurgerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.SERVICES.Interfaces
{
    public interface IBurgerService
    {
        List<BurgerViewModel> GetAllBurgers();
        BurgerViewModel GetBurgerById(int id);
        void EditBurger(BurgerViewModel burgerViewModel);
        void AddBurger(BurgerViewModel burgerViewModel);
        void DeleteBurger(int id);
        List<BurgerNamesDDViewModel> GetBurgerNamesForDD();
        
    }
}
