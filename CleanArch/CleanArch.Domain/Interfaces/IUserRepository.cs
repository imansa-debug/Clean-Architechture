using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
   public interface IUserRepository
    {
        void AddUser(User user);
        bool IsExistUserName(string userName);
        bool IsExistEmail(string Email);
        void Save();
      
    }
}
