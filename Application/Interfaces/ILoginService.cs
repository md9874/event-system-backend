using Application.DTO.LoginDTOs;
using Application.DTO.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ILoginService
    {
        UserDTO Login(LoginDTO userPass);
    }
}
