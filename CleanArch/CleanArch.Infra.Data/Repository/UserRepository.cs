using System;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using System.Threading.Tasks;
using System.Linq;
namespace CleanArch.Infra.Data.Repository
{

    public class UserRepository : IUserRepository
    {
        private UniversityDbContext _ctx;

        public UserRepository(UniversityDbContext ctx)
        {
            _ctx = ctx;

        }
        
        public void AddUser(User user)
        {
            _ctx.Add(user);
        }

        public bool IsExistEmail(string Email)
        {
            return _ctx.Users.Any(u => u.Email == Email);
        }

        public bool IsExistUserName(string userName)
        {
          
            
            return  _ctx.Users.Any(u => u.UserName == userName);
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }
    }

}