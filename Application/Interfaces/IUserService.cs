using Application.DTO.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUsers();
        UserDetailsDTO GetUserDetails(int id);
        UserDetailsDTO AddNewUser(CreateUserDTO newUser);
        void ChangePassword(ChangeUserPasswordDTO updatedUser);
    }
}
