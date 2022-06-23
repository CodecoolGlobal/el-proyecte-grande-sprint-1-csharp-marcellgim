using System.ComponentModel.DataAnnotations;

namespace BpRobotics.Core.Model.UserDTOs;

public class UserUpdateDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Password { get; set; }
}