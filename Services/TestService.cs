using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YouthAtHeart.Models;

namespace YouthAtHeart.Services
{
    public class TestService
    {
        private Models.YouthAtHeartContext _context;
        public TestService(Models.YouthAtHeartContext context)
        {
            _context = context;
        }
        public List<Test> GetAllTest() {
            List<Test> AllTest = _context.Test.ToList();
            return AllTest;

        }

    }
}
