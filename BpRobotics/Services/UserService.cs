using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace BpRobotics.Services;

public class UserService
{
    private readonly IRepository<User> _userRepository;

    public UserService(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> ListUsers() => await _userRepository.GetAll();

    public async Task NewUser(User newUser)
    {
        await _userRepository.Add(newUser);
    }

    public async Task<User> GetById(int userId) => await _userRepository.Get(userId);

    public async Task DeleteById(int userId) => await _userRepository.Delete(userId);
}