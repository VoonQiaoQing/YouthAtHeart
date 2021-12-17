using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouthAtHeart.Models;

namespace YouthAtHeart.Services
{
    public class HomeInfoService
    {
        private Models.YouthAtHeartContext _context;
        public HomeInfoService(Models.YouthAtHeartContext context)
        {
            _context = context;
        }
        public List<HomeInfo> GetAllTest()
        {
            List<HomeInfo> Homeinfo = _context.HomeInfo.ToList();
            return Homeinfo;
        }
    }
}
