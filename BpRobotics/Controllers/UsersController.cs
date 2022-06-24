using BpRobotics.Core.Model.UserDTOs;
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
        public async Task<ActionResult<List<UserViewDto>>> ListUsers()
        {
            return await _userService.ListUsers();
        }

        [HttpPost]
        public async Task<ActionResult<UserViewDto>> NewUser(UserCreateDto newUser)
        {
            try
            {
                var createdUser = await _userService.NewUser(newUser);
                return CreatedAtRoute("GetUser",new {userId = createdUser.Id}, createdUser);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{userId}", Name = "GetUser")]
        public async Task<ActionResult<UserViewDto>> GetUser(int userId)
        {
            try
            {
                return await _userService.GetById(userId);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            { 
                await _userService.DeleteById(userId);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<UserViewDto>> UpdateUser(UserUpdateDto updatedUser)
        {
            try
            {
                return await _userService.UpdateUser(updatedUser);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
