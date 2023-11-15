using Application.DTO.UserDTOs;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [SwaggerOperation(Summary = "Retrieves all users")]
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [SwaggerOperation(Summary = "Retrieves a specific user by unique id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.GetUserDetails(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [SwaggerOperation(Summary = "Create a new user")]
        [HttpPost]
        public IActionResult Create(CreateUserDTO newUser)
        {
            var user = _userService.AddNewUser(newUser);
            return Created($"api/user/{user.Id}", user);
        }

        [SwaggerOperation(Summary = "Change password a existing user")]
        [HttpPut("password")]
        public IActionResult ChangePassword(ChangeUserPasswordDTO updatedUser)
        {
            _userService.ChangePassword(updatedUser);
            return NoContent();
        }
    }
}
