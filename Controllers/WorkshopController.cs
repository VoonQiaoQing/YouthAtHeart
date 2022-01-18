using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
