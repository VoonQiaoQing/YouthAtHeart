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
    public class EditWorkshopModel : PageModel
    {
        private readonly WorkshopInfoService _svc;
        public EditWorkshopModel(WorkshopInfoService service) //constructor: same name as class
        {
            _svc = service; //service object is automatically created when object of CreateModel is created
        }

        [BindProperty]
        public WorkshopInfo EditAWorkshop { get; set; }

        [BindProperty]
        public IFormFile CoverImage { get; set; }

        [BindProperty]
        public IFormFile EnvImage { get; set; }

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
            else
            {
/*                var coverImage = DeleteAWorkshop.wsCoverImage;
                var envImage = DeleteAWorkshop.wsEnvImage;

                var coverImagepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image")).Root + $@"\{coverImage}";
                var envImagepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image")).Root + $@"\{envImage}";

                System.IO.File.Delete(coverImagepath);
                System.IO.File.Delete(envImagepath);*/

                foreach (var file in Request.Form.Files)
                {
                    if (CoverImage != null)
                    {
/*                        var coverImage = EditAWorkshop.wsCoverImage;
                        var coverImagepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image")).Root + $@"\{coverImage}";
                        System.IO.File.Delete(coverImagepath);*/

                        var fileName = Path.GetFileName(CoverImage.FileName);

                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        var fileExtension = Path.GetExtension(fileName);

                        var newFileName = String.Concat(myUniqueFileName, fileExtension);

                        var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image")).Root + $@"\{newFileName}";

                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            CoverImage.CopyTo(fs);
                            fs.Flush();

                        }
                        EditAWorkshop.wsCoverImage = newFileName;
                        
                    }
                    else
                    {
                        EditAWorkshop.wsCoverImage = EditAWorkshop.wsCoverImage;
                    }

                    if (EnvImage != null)
                    {
/*                        var envImage = EditAWorkshop.wsEnvImage;
                        var envImagepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image")).Root + $@"\{envImage}";
                        System.IO.File.Delete(envImagepath);*/

                        var fileName = Path.GetFileName(EnvImage.FileName);

                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        var fileExtension = Path.GetExtension(fileName);

                        var newFileName = String.Concat(myUniqueFileName, fileExtension);

                        var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image")).Root + $@"\{newFileName}";

                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            EnvImage.CopyTo(fs);
                            fs.Flush();

                        }
                        EditAWorkshop.wsEnvImage = newFileName;
                    }
                    else
                    {
                        EditAWorkshop.wsEnvImage = EditAWorkshop.wsEnvImage;
                    }
                }
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
