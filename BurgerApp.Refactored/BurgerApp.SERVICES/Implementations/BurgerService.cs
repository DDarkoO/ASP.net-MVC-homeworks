using BurgerApp.DATA_ACCESS;
using BurgerApp.DOMAIN.Models;
using BurgerApp.MAPPERS;
using BurgerApp.SERVICES.Interfaces;
using BurgerApp.VIEWMODELS.BurgerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.SERVICES.Implementations
{
    public class BurgerService : IBurgerService
    {
        private IRepository<Burger> _burgerRepository;
        

        public BurgerService(IRepository<Burger> burgerRepository)
        {
            _burgerRepository = burgerRepository;
        }

        public void EditBurger(BurgerViewModel burgerViewModel)
        {            
            Burger burger = _burgerRepository.GetById(burgerViewModel.Id);
            if(burger == null)
            {
                throw new Exception("There is no such burger in our menu.");
            }

            //burger.Id = burgerViewModel.Id;
            burger.Name = burgerViewModel.Name;
            burger.IsVegetarian = burgerViewModel.IsVegetarian;
            burger.IsVegan = burgerViewModel.IsVegan;
            burger.HasFries = burgerViewModel.HasFries;
            burger.Price = burgerViewModel.Price;

            _burgerRepository.Edit(burger);
        }

        public List<BurgerViewModel> GetAllBurgers()
        {
            List<Burger> burgersDb = _burgerRepository.GetAll();

            List<BurgerViewModel> burgerViewModels = burgersDb.Select(x => x.ToBurgerViewModel()).ToList();

            return burgerViewModels;
        }

        public BurgerViewModel GetBurgerById(int id)
        {
            Burger burger = _burgerRepository.GetById(id);
            if(burger == null)
            {
                throw new Exception("There is no such burger in our menu.");
            }

            BurgerViewModel burgerViewModel = burger.ToBurgerViewModel();
            return burgerViewModel;
        }

        void IBurgerService.AddBurger(BurgerViewModel burgerViewModel)
        {
            if (string.IsNullOrEmpty(burgerViewModel.Name))
            {
                throw new Exception("You need to enter a name for the new burger.");
            }
            
            List<Burger> allBurgers = _burgerRepository.GetAll();

            bool nameExists = allBurgers.Any(x => x.Name == burgerViewModel.Name);

            if (nameExists)
            {
                throw new Exception("You need to pick another name. A burger with that name already exists in our menu.");
            }

            if(burgerViewModel.Price <= 0)
            {
                throw new Exception("Free burgers will have negative impact over our business...");
            }

            Burger newBurger = burgerViewModel.ToBurger();
            _burgerRepository.Insert(newBurger);
        }

        void IBurgerService.DeleteBurger(int id)
        {
            Burger burger = _burgerRepository.GetById(id);
            if(burger == null)
            {
                throw new Exception("There is no such burger in our menu");
            }

            _burgerRepository.DeleteById(id);           

        }

        List<BurgerNamesDDViewModel> IBurgerService.GetBurgerNamesForDD()
        {
            List<Burger> allBurgers = _burgerRepository.GetAll();
            List<BurgerNamesDDViewModel> allBurgerNames = allBurgers.Select(x => x.ToBurgerNamesDDViewModel()).ToList();
            return allBurgerNames;
        }

        
    }
}
