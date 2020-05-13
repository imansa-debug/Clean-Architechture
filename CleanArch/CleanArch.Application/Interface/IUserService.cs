using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Interface
{
   public interface IUserService
    {
        CheckUser checkUser(string username, string email);
        int RegisterUser(User user);
    }
}
