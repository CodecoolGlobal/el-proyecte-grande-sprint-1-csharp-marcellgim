using BpRobotics.Core.Extensions;
using BpRobotics.Core.Model.UserDTOs;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BpRobotics.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly IRepository<Customer> _customerRepository;
    private readonly IRepository<Partner> _partnerRepository;

    public UserService(IUserRepository userRepository, IRepository<Customer> customerRepository, IRepository<Partner> partnerRepository)
    {
        _userRepository = userRepository;
        _customerRepository = customerRepository;
        _partnerRepository = partnerRepository;
    }

    public async Task<List<UserViewDto>> ListPartnerUsers()
    {
        return (await _userRepository.GetAll())
            .Where(user => user.Role == UserRole.Partner)
            .Where(user => user.Partners?.Count==0)
            .Select(user => user.ToUserView())
            .ToList();
    }

    public async Task<List<UserViewDto>> ListCustomerUsers()
    {
        return (await _userRepository.GetAll())
            .Select(user => user.ToUserView())
            .Where(user => user.Role == UserRole.Customer.ToString())
            .ToList();
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
    public async Task<UserLoginDto> GetLoginDtoByUserName(string username)
    {
        var user = await _userRepository.GetByUserName(username);
        var functionId = await GetFunctionId(user);

        return user.ToUserLoginDto(functionId);
    } 

    public async Task DeleteById(int userId) => await _userRepository.Delete(userId);

    public async Task<UserViewDto> UpdateUser(UserUpdateDto updatedUser)
    {
        return (await _userRepository.Update(updatedUser.ToUserEntity())).ToUserView();
    }

    private async Task<int?> GetFunctionId(User user)
    {
        if (user.Role == UserRole.Customer)
        {
            var customers = await _customerRepository.GetAll();
            return customers.Single(customer => customer.User.Id == user.Id)?.Id;
        }
        
        if (user.Role == UserRole.Partner)
        {
            var partners = await _partnerRepository.GetAll();
            return partners.Single(partner => partner.User.Id == user.Id)?.Id;
        }
     
        return null;
    }
}