using System.ComponentModel.DataAnnotations;

namespace BpRobotics.Core.Model.User;

public class UserUpdateDto
{
    [Required]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}