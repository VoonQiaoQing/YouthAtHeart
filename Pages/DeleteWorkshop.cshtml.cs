using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YouthAtHeart.Models;
using YouthAtHeart.Services;

namespace YouthAtHeart.Pages
{
    public class DeleteWorkshopModel : PageModel
    {
        private readonly WorkshopInfoService _svc;
        public DeleteWorkshopModel(WorkshopInfoService service) //constructor: same name as class
        {
            _svc = service; //service object is automatically created when object of CreateModel is created
        }

        [BindProperty]
        public WorkshopInfo DeleteAWorkshop { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DeleteAWorkshop = _svc.GetWorkshopById(id);
            if (DeleteAWorkshop == null)
            {
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DeleteAWorkshop = _svc.GetWorkshopById(id);
            if (_svc.DeleteWorkshop(DeleteAWorkshop) == true)
            {
                return RedirectToPage("WorkshopListing");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
