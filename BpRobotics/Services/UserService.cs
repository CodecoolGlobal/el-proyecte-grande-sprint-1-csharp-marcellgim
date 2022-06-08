using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;
using Microsoft.VisualBasic;

namespace BpRobotics.Services;

public class UserService
{
    private readonly IRepository<User> _userRepository;

    public UserService(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public List<User> ListUsers() => _userRepository.GetAll();

    public void NewUser(User newUser)
    {
        _userRepository.Add(newUser);
    }
}