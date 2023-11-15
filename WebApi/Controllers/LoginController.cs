using Application.DTO.LoginDTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [SwaggerOperation(Summary = "Create a new user")]
        [HttpPost]
        public IActionResult Login(LoginDTO userPass)
        {
            var user = _loginService.Login(userPass);

            if(user == null)
            {
                return NoContent();
            }
            return Ok(user);
        }
    }
}
