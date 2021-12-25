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
    public class WorkshopListingModel : PageModel
    {
        [BindProperty]
        public List<WorkshopInfo> allworkshops { get; set; }

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
            //Guid guid = Guid.NewGuid();
        }

        public void OnPost()
        {

        }
    }
}
