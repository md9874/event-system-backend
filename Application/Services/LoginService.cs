using Application.DTO.LoginDTOs;
using Application.DTO.UserDTOs;
using Application.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    internal class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDTO Login(LoginDTO userPass)
        {
            var user = _userRepository.GetAll()
                .Where(x => x.Nick == userPass.Nick && x.Password == userPass.Password)
                .Single();

            return new UserDTO()
            {
                Id = user.Id,
                Nick = user.Nick
            };
        }
    }
}
