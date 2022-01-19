﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq.Dynamic.Core;
using YouthAtHeart.Models;
using YouthAtHeart.Services;

namespace YouthAtHeart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopListingController : ControllerBase
    {

        private readonly YouthAtHeartContext context;

        public WorkshopListingController(YouthAtHeartContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult GetCustomers()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                var customerData = (from tempcustomer in context.WorkshopInfo select tempcustomer);
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.wsName.Contains(searchValue)
                                                || m.wsMainInfo.Contains(searchValue)
                                                || m.wsExtraInfo.Contains(searchValue)
                                                || m.wsType.Contains(searchValue)
                                                || m.wsLocationType.Contains(searchValue)
                                                || m.wsLocationDetails.Contains(searchValue)
                                                || m.wsLessonSchedule.Contains(searchValue)
                                                );
                }
                recordsTotal = customerData.Count();
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}