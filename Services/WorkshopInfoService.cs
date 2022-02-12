using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

        private bool WorkshopExists(string id)
        {
            return _context.WorkshopInfo.Any(e => e.wsId == id);
        }

        public bool AddWorkshop(WorkshopInfo newworkshop)
        {
            if (WorkshopExists(newworkshop.wsId))
            {
                return false;
            }

            Guid guid = Guid.NewGuid();
            //string guidTostring = guid.ToString();

            //CreateAWorkshop.wsId = guidTostring;
            //WorkshopId = CreateAWorkshop.wsId;
            //WorkshopId = guid.ToString();

            newworkshop.wsId = guid.ToString();

            _context.Add(newworkshop);
            _context.SaveChanges();
            return true;
        }

        public WorkshopInfo GetWorkshopById(string id)
        {
            WorkshopInfo Workshop = _context.WorkshopInfo.Where(e => e.wsId == id).FirstOrDefault();
            return Workshop;
        }
        public bool UpdateWorkshop(WorkshopInfo theworkshop)
        {
            bool updated = true;
            _context.Attach(theworkshop).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
                updated = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkshopExists(theworkshop.wsId))
                {
                    updated = false;
                }
                else
                {
                    throw;
                }
            }
            return updated;
        }

        public bool DeleteWorkshop(WorkshopInfo theworkshop)
        {
            bool deleted = true;
            try
            {
                _context.Remove(theworkshop);
                _context.SaveChanges();
                deleted = true;

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkshopExists(theworkshop.wsId))
                {
                    deleted = false;
                }
                else
                {
                    throw;
                }
            }
            return deleted;
        }

    }
}
