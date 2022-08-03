using BpRobotics.Core.Model.UserDTOs;
using BpRobotics.Data.Entity;
using BpRobotics.Services;
using BpRobotics.Services.PasswordHasher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BpRobotics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IPasswordHasher _hasher;

        public UsersController(UserService userService, IPasswordHasher hasher)
        {
            _userService = userService;
            _hasher = hasher;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserViewDto>>> ListUsers()
        {
            return await _userService.ListUsers();
        }

        [HttpGet("partners")]
        public async Task<ActionResult<List<UserViewDto>>> ListPartnerUsers()
        {
            return await _userService.ListPartnerUsers();
        }

        [HttpGet("customers")]
        public async Task<ActionResult<List<UserViewDto>>> ListCustomerUsers()
        {
            return await _userService.ListCustomerUsers();
        }

        [HttpPost]
        public async Task<ActionResult<UserViewDto>> NewUser(UserCreateDto newUser)
        {
            newUser.Password = _hasher.HashPassword(newUser.Password);
            try
            {
                var createdUser = await _userService.NewUser(newUser);
                return CreatedAtRoute("GetUser",new {userId = createdUser.Id}, createdUser);
            }
            catch (DbUpdateException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{userId}", Name = "GetUser")]
        public async Task<ActionResult<UserViewDto>> GetUser(int userId)
        {
            try
            {
                return await _userService.GetById(userId);
            }
            catch (InvalidOperationException)
            {
                return NotFound($"User with ID:{userId} not found.");
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
            catch (InvalidOperationException)
            {
                return NotFound($"User with ID:{userId} not found.");
            }
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<UserViewDto>> UpdateUser(UserUpdateDto updatedUser)
        {
            try
            {
                return await _userService.UpdateUser(updatedUser);
            }
            catch (DbUpdateException)
            {
                return NotFound($"User with ID:{updatedUser.Id} not found.");
            }
        }
    }
}
