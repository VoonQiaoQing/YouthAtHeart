using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouthAtHeart.Models;

namespace YouthAtHeart.Services
{
    public class WorkshopInfoService
    {
        private Models.YouthAtHeartContext _context;
        public WorkshopInfoService(Models.YouthAtHeartContext context)
        {
            _context = context;
        }
        public List<WorkshopInfo> GetAllWorkshops()
        {
            List<WorkshopInfo> Allworkshops = _context.WorkshopInfo.ToList();
            return Allworkshops;
        }
    }
}
