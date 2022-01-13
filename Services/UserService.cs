using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouthAtHeart.Services
{
    public class UserService
    {
        private Models.YouthAtHeartContext _context;
        public UserService(Models.YouthAtHeartContext context)
        {
            _context = context;
        }
    }
}
