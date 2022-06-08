namespace BpRobotics.Data.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string HashedPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }
        public Customer? Customer { get; set; }
        public Partner? Partner { get; set; }
    }
}