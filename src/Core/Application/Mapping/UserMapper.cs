using Application.InputModels;
using Application.ViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class UserMapper
    {
        //user input model to user entity
        //user entity to user view model

        public static User MapUser(UserInputModel userInputModel)
        {
            return new User
            {
                Id = userInputModel.Id.HasValue ? userInputModel.Id.Value : Guid.NewGuid(),
                Username = userInputModel.Username,
                Email = userInputModel.Email,
                Password = userInputModel.Password,
                CreatedAt = DateTime.Now,
            };
        }

        public static UserViewModel MapUserViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
            };
        }
    }

}
