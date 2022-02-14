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
            allworkshops = _svc.GetAllWorkshops().OrderBy(f => f.dateCreated).ToList();

        }
    }
}