using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;

namespace BpRobotics.Services;

public class UserService
{
    private readonly IRepository<User> _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<User> ListUsers() => _userRepository.GetAll();
}