using BpRobotics.Data.Entity;

namespace BpRobotics.Core.Model
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }
    }
}