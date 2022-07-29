using BurgerApp.DATA.ACCESS;
using BurgerApp.DATA.ACCESS.Implementations;
using BurgerApp.DOMAIN.Models;
using BurgerApp.MAPPERS;
using BurgerApp.SERVICES.Interfaces;
using BurgerApp.VIEWMODELS.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.SERVICES.Implementations
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public List<UserViewModelDD> GetUsersForDD()
        {
            return _userRepository.GetAll().Select(x => x.ToUserViewModelDD()).ToList();
        }
    }
}
