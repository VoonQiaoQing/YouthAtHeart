using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouthAtHeart.Models;
using YouthAtHeart.Services;
using Google.Cloud.Translation.V2;

namespace YouthAtHeart.Pages
{
    public class WorkshopListingModel : PageModel
    {
        [BindProperty]
        public List<WorkshopInfo> allworkshops { get; set; }

        [BindProperty]
        public string noworkshops { get; set; }

        public List<WorkshopInfo> notbinded_allworkshops { get; set; }



        private readonly ILogger<WorkshopListingModel> _logger;
        private WorkshopInfoService _svc;

        public WorkshopListingModel(ILogger<WorkshopListingModel> logger, WorkshopInfoService service)
        {
            _logger = logger;
            _svc = service;
        }

        public void OnGet()
        {
            //ERROR SHOULD BE HERE
            allworkshops = _svc.GetAllWorkshops();
        }

        public void OnPost()
        {



        }
    }
}
