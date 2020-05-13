using CleanArch.Application.Interface;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public CheckUser checkUser(string username, string email)
        {
            bool userNameValid = _userRepository.IsExistUserName(username);
            bool emailValid = _userRepository.IsExistEmail(email);


            if (userNameValid && emailValid)
            {
                return CheckUser.UserNameAndEmailNotValid;
            }
            else if (emailValid)
            {
                return CheckUser.EmailNotValid;
            }
            else if (userNameValid)
            {
                return CheckUser.UserNameNotValid;
            }

            return CheckUser.OK;

            
        }

        public int RegisterUser(User user)
        {
            _userRepository.AddUser(user);
            _userRepository.Save();
            return user.UserId;
        }
    }
}
