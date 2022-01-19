using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YouthAtHeart.Models;

namespace YouthAtHeart.Services
{
    public class UserService
    {
        private Models.YouthAtHeartContext _context;
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
        private bool UserExits(string id)
        {
            return _context.User.Any(e => e.userId == id);
        }

        public bool AddUser(User newuser)
        {
            if (UserExits(newuser.userId)) 
            {
                return false;
            }
            Guid guid = Guid.NewGuid();
            newuser.userId = guid.ToString();
            _context.Add(newuser);
            _context.SaveChanges();
            return true;
        }

        public User GetUserbyId(string id)
        {
            User user = (User)_context.User.Where(e => e.userId == id);
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
                if (!UserExits(user.userId))
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
                if (!UserExits(user.userId))
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
