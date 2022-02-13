using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using YouthAtHeart.Models;

namespace YouthAtHeart.Services
{
    public class UserService
    {
        private readonly  Models.YouthAtHeartContext _context;
        public UserService(Models.YouthAtHeartContext context)
        {
            _context = context;
        }
        public List<User> GetAllUsers()
        {
            List<User> AllUsers = new List<User>();
            AllUsers = _context.User.ToList();
            return AllUsers;
        }
        public bool UserExits(string name)
        {
            return _context.User.Any(e => e.username == name);
        }

        public bool AddUser(User newuser)
        {
            if (UserExits(newuser.username)) 
            {
                return false;
            }
            Guid guid = Guid.NewGuid();
            newuser.userId = guid.ToString();
            _context.Add(newuser);
            _context.SaveChanges();
            return true;
        }

        public User GetUserbyId(string name)
        {
            User user = _context.User.Where(e => e.username == name).FirstOrDefault();
            return user;
        }

        public bool UpdateUser(User user)
        {
            _context.Attach(user).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExits(user.username))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }
        
        public bool DeleteUser(User user)
        {
            try
            {
                _context.Remove(user);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExits(user.username))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

        }
    }
}
