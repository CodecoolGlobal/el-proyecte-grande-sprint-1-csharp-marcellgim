using BpRobotics.Data.Entity;
using BpRobotics.Services;
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
        public ActionResult<User> NewUser([FromBody] User newUser)
        {
            try
            {
                _userService.NewUser(newUser);
                return CreatedAtRoute("GetUser",new {userId = newUser.Id}, newUser);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{userId}", Name = "GetUser")]
        public ActionResult<User> GetUser(int userId)
        {
            try
            {
                return _userService.GetById(userId);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
