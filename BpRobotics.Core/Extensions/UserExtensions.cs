using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BpRobotics.Core.Model.UserDTOs;
using BpRobotics.Data.Entity;

namespace BpRobotics.Core.Extensions
{
    public static class UserExtensions
    {
        public static User ToUserEntity(this UserCreateDto userCreateData)
        {
            UserRole role = Enum.Parse<UserRole>(userCreateData.Role);
            return new User
            {
                UserName = userCreateData.UserName,
                FirstName = userCreateData.FirstName,
                LastName = userCreateData.LastName,
                HashedPassword = userCreateData.Password,
                Role = role
            };
        }
        public static User ToUserEntity(this UserUpdateDto userUpdateData)
        {
            return new User
            {
                UserName = userUpdateData.UserName,
                Id = userUpdateData.Id,
                FirstName = userUpdateData.FirstName,
                LastName = userUpdateData.LastName,
                HashedPassword = userUpdateData.Password,
            };
        }

        public static UserViewDto ToUserView(this User user)
        {
            return new UserViewDto
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role.ToString(),
            };
        }

        public static UserLoginDto ToUserLoginDto(this User user, int? functionId = null)
        {
            return new UserLoginDto
            {
                Id = user.Id,
                Role = user.Role,
                UserName = user.UserName,
                HashedPassword = user.HashedPassword,
                FunctionId = functionId
            };
        }
    }
}
