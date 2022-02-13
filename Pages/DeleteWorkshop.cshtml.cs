using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.FileProviders;
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

            var coverImage = DeleteAWorkshop.wsCoverImage;
            var envImage = DeleteAWorkshop.wsEnvImage;

            var coverImagepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image")).Root + $@"\{coverImage}";
            var envImagepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image")).Root + $@"\{envImage}";
            
            System.IO.File.Delete(coverImagepath);
            System.IO.File.Delete(envImagepath);

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
