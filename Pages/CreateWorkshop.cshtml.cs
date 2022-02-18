using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YouthAtHeart.Models;
using Microsoft.EntityFrameworkCore;
using YouthAtHeart.Services;
using System.IO;

//Password Checker
using System.Text.RegularExpressions;
using System.Drawing;
//Password with Hash and Salt
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.FileProviders;

namespace YouthAtHeart.Pages
{
    public class CreateWorkshopModel : PageModel
    {
        private readonly Services.WorkshopInfoService _svc;
        public CreateWorkshopModel(Services.WorkshopInfoService service) //constructor: same name as class
        {
            _svc = service; //service object is automatically created when object of CreateModel is created
        }
        //hello
        [BindProperty]
        public string WorkshopId { get; set; }

        [BindProperty]
        public WorkshopInfo CreateAWorkshop { get; set; }

        [BindProperty]
        public string MyMessage { get; set; }

        [BindProperty]
        public IFormFile CoverImage { get; set; }

        [BindProperty]
        public IFormFile EnvImage { get; set; }

        public void OnGet()
        {
            Guid guid = Guid.NewGuid();
            string guidTostring = guid.ToString();

            //CreateAWorkshop.wsId = guidTostring;
            //WorkshopId = CreateAWorkshop.wsId;
            //WorkshopId = guid.ToString();
        }
        
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                foreach (var file in Request.Form.Files)
                {
                    if (CoverImage != null)
                    {
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
                        CreateAWorkshop.wsCoverImage = newFileName;
                    }

                    if (EnvImage != null)
                    {
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
                        CreateAWorkshop.wsEnvImage = newFileName;
                    }
                }

                string teacherName = HttpContext.Session.GetString("userName");
                if (_svc.AddWorkshop(CreateAWorkshop, teacherName))
                {
                    // Create session

                    //HttpContext.Session.SetString("SSName", MyEmployee.Name);
                    //HttpContext.Session.SetString("SSDept", MyEmployee.Department.ToString());
                    return RedirectToPage("WorkshopListing");
                }

                else
                {
                    MyMessage = "Workshop Id already exist!";
                    return Page();
                }
                
                
            }
            return Page();

        }
    }
}
