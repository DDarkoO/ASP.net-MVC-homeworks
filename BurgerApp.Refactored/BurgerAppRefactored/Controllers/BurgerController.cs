using BurgerApp.SERVICES.Interfaces;
using BurgerApp.VIEWMODELS;
using BurgerApp.VIEWMODELS.BurgerViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerAppRefactored.Controllers
{
    public class BurgerController : Controller
    {
        private IBurgerService _burgerService;

        public BurgerController(IBurgerService burgerService)
        {
            _burgerService = burgerService;
        }


        public IActionResult BurgersMenu()
        {
            List<BurgerViewModel> burgerViewModels = _burgerService.GetAllBurgers();
            return View(burgerViewModels);
        }

        public IActionResult EditBurger(int? id)
        {
            if (id == null)
            {
                return View("Resource not found");
            }

            try
            {
                BurgerViewModel burgerViewModelForEdit = _burgerService.GetBurgerById(id.Value);
                return View(burgerViewModelForEdit);
            }
            catch (Exception e)
            {
                return View("ResourceNotFound");
            }

        }

        [HttpPost]
        public IActionResult EditBurgerPost(BurgerViewModel burgerViewModelForEdit)
        {
            _burgerService.EditBurger(burgerViewModelForEdit);
            return RedirectToAction("BurgersMenu");
        }

        public IActionResult AddBurger()
        {
            BurgerViewModel burgerViewModel = new BurgerViewModel();
            return View(burgerViewModel);
        }

        [HttpPost]
        public IActionResult AddBurgerPost(BurgerViewModel newBurgerViewModel)
        {
            _burgerService.AddBurger(newBurgerViewModel);
            return RedirectToAction("BurgersMenu");
        }

        public IActionResult DeleteBurger(int? id)
        {
            if (id == null || id <= 0)
            {
                return View("ResourceNotFound");
            }

            try
            {
                BurgerViewModel burgerViewModel = _burgerService.GetBurgerById(id.Value);
                return View(burgerViewModel);
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        public IActionResult ConfirmDelete(int? id)
        {
            if (id == null)
            {
                return View("ResourceNotFound");
            }

            try
            {
                _burgerService.DeleteBurger(id.Value);
                return RedirectToAction("BurgersMenu");
            }
            catch (Exception e)
            {
                return View("Error");
            }

        }


    }
}
