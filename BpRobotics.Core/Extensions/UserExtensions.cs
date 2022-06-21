using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BpRobotics.Core.Model.User;
using BpRobotics.Data.Entity;

namespace BpRobotics.Core.Extensions
{
    public static class UserExtensions
    {
        public static User ToUserEntity(this UserCreateDto userCreateData)
        {
            UserRole role = Enum.Parse<UserRole>(userCreateData.Role);
            User newUser;

            switch (role)
            {
                case UserRole.Admin:
                    newUser = new AdminUser();
                    break;
                case UserRole.Customer:
                    newUser = new CustomerUser { RelatedEntityId = (int)userCreateData.RelatedEntityId };
                    break;
                case UserRole.Partner:
                    newUser = new PartnerUser { RelatedEntityId = (int)userCreateData.RelatedEntityId };
                    break;
                default:
                    newUser = new AdminUser();
                    break;
            }

            newUser.UserName = userCreateData.UserName;
            newUser.HashedPassword = userCreateData.Password;
            newUser.Role = role;

            return newUser;
        }

        public static UserViewDto ToUserView(this User user)
        {
            int? relatedId = null;

            if (user is CustomerUser customerUser)
            {
                relatedId = customerUser.RelatedEntityId;
            }
            else if (user is PartnerUser partnerUser)
            {
                relatedId = partnerUser.RelatedEntityId;
            }

            return new UserViewDto
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role.ToString(),
                RelatedEntityId = relatedId
            };
        }
    }
}
