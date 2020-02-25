using ReactChat.BusinessLogicLayer.Models;
using ReactChat.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.BusinessLogicLayer.Helpers.Mapper
{
    public static class MapApplicationUser
    {
        public static ApplicationUser MapFromUserModel(UserModel userModel)
        {
            return new ApplicationUser
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                UserName = userModel.UserName,
                PhoneNumber = userModel.PhoneNumber,
                PhoneNumberConfirmed = userModel.PhoneNumberConfirmed
            };
        }
        public static UserModel MapFromApplicationUser(ApplicationUser applicationUser)
        {
            return new UserModel
            {
                Id = applicationUser.Id,
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                PhoneNumber = applicationUser.PhoneNumber,
                PhoneNumberConfirmed = applicationUser.PhoneNumberConfirmed
            };
        }
    }
}
