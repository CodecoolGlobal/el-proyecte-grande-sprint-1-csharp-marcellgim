using BpRobotics.Core.Model;
using BpRobotics.Data.Repositories;

namespace BpRobotics.Data.Services;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<UserModel> ListUsers()
    {
        throw new NotImplementedException();
    }
}