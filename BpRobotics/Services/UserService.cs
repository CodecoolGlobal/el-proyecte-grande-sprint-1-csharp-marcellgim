using BpRobotics.Core.Extensions;
using BpRobotics.Core.Model.UserDTOs;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BpRobotics.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserViewDto>> ListUsers()
    {
        return (await _userRepository.GetAll())
            .Select(user => user.ToUserView())
            .ToList();
    } 

    public async Task<UserViewDto> NewUser(UserCreateDto newUser)
    {
        var userEntity = newUser.ToUserEntity();
        await _userRepository.Add(userEntity);
        return userEntity.ToUserView();
    }

    public async Task<UserViewDto> GetById(int userId) => (await _userRepository.Get(userId)).ToUserView();
    public async Task<UserLoginDto> GetLoginDtoByUserName(string username) => (await _userRepository.GetByUserName(username)).ToUserLoginDto();

    public async Task DeleteById(int userId) => await _userRepository.Delete(userId);

    public async Task<UserViewDto> UpdateUser(UserUpdateDto updatedUser)
    {
        return (await _userRepository.Update(updatedUser.ToUserEntity())).ToUserView();
    }
}