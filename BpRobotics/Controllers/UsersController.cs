using BpRobotics.Data.Entity;
using BpRobotics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BpRobotics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public List<User> ListUsers()
        {
            return _userService.ListUsers();
        }
    }
}
