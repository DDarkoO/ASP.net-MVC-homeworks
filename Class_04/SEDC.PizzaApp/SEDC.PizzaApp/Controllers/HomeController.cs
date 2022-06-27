﻿using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;
using System.Diagnostics;

namespace SEDC.PizzaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //localhost:[port]/AboutUs
        [Route("AboutUs")]
        public IActionResult About()
        {
            return View();
        }

        //localhost:[port]/Home/Contact
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SeeUsers() 
        {
            List<UserViewModel> userViewModels = StaticDb.Users.Select(x => x.ToUserViewModel()).ToList();

            ViewData["listOfUsers"] = "The following users are currently part of our user database:";
                        
            return View(userViewModels);
        }
    }
}