using ReactChat.BusinessLogicLayer.Models;
using ReactChat.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.BusinessLogicLayer.Helpers.Mapper
{
    public static class MapApplicationUser
    {
        public static ApplicationUser MapFromSignUpModel(SignUpModel signUpModel)
        {
            return new ApplicationUser
            {
                FirstName = signUpModel.FirstName,
                LastName = signUpModel.LastName,
                PhoneNumber = signUpModel.PhoneNumber,
                UserName = signUpModel.UserName
            };
        }
        public static ApplicationUser MapFromUserModel(UserModel userModel)
        {
            return new ApplicationUser
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                UserName = userModel.UserName,
                PhoneNumber = userModel.PhoneNumber,
                PhoneNumberConfirmed = userModel.PhoneVerified
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
                PhoneVerified = applicationUser.PhoneNumberConfirmed
            };
        }
    }
}
