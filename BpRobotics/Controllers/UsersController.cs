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

        [HttpPost]
        public ActionResult NewUser([FromBody] User newUser)
        {
            try
            {
                _userService.NewUser(newUser);
                return Created($"/user/{newUser.Id}", newUser);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
