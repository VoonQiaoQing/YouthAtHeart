using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.FileProviders;
using YouthAtHeart.Models;
using YouthAtHeart.Services;


namespace YouthAtHeart.Pages
{
    public class WorkshopDetailModel : PageModel
    {
        private readonly WorkshopInfoService _svc;
        public WorkshopDetailModel(WorkshopInfoService service) //constructor: same name as class
        {
            _svc = service; //service object is automatically created when object of CreateModel is created
        }

        [BindProperty]
        public WorkshopInfo WorkshopDetail { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            WorkshopDetail = _svc.GetWorkshopById(id);

            if (WorkshopDetail == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
