using BpRobotics.Data.Entity;

namespace BpRobotics.Core.Model.User;

public class UserViewDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
    public int? RelatedEntityId { get; set; }
}