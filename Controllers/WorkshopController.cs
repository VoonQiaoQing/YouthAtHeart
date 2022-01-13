using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Datatables.ServerSide.Data;
using Microsoft.AspNetCore.Http;
using System.Linq.Dynamic.Core;

namespace YouthAtHeart.Controllers
{
    public class WorkshopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
