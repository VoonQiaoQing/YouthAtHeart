using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouthAtHeart.Models;
using YouthAtHeart.Services;

namespace YouthAtHeart.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<WorkshopInfo> allworkshops { get; set; }

        [BindProperty]
        public int lastest1 { get; set; }

        [BindProperty]
        public int lastest2 { get; set; }

        [BindProperty]
        public int lastest3 { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly WorkshopInfoService _svc;

        public IndexModel(ILogger<IndexModel> logger, WorkshopInfoService service)
        {
            _logger = logger;
            _svc = service;
        }

        public void OnGet()
        {
            allworkshops = _svc.GetAllWorkshops();
            int number = allworkshops.Count;
            if (number == 0)
            {
                lastest1 = -1;
                lastest2 = -1;
                lastest3 = -1;
            }
            if (number == 1)
            {
                lastest1 = 0;
                lastest2 = -1;
                lastest3 = -1;
            }
            if (number == 2)
            {
                lastest1 = 1;
                lastest2 = 0;
                lastest3 = -1;
            }
            if (number == 3)
            {
                lastest1 = 2;
                lastest2 = 1;
                lastest3 = 0;
            }
            else
            {
                lastest1 = number;
                lastest2 = number - 1;
                lastest3 = number - 2;
            }
        }
    }
}