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
    public class EditWorkshopModel : PageModel
    {
        private readonly WorkshopInfoService _svc;
        public EditWorkshopModel(WorkshopInfoService service) //constructor: same name as class
        {
            _svc = service; //service object is automatically created when object of CreateModel is created
        }

        [BindProperty]
        public WorkshopInfo EditAWorkshop { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EditAWorkshop = _svc.GetWorkshopById(id);
            if (EditAWorkshop == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (_svc.UpdateWorkshop(EditAWorkshop) == true)
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
