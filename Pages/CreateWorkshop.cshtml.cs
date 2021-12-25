using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YouthAtHeart.Models;
using YouthAtHeart.Services;

namespace YouthAtHeart.Pages
{
    public class CreateWorkshopModel : PageModel
    {

        private readonly Services.WorkshopInfoService _svc;
        public CreateWorkshopModel(Services.WorkshopInfoService service) //constructor: same name as class
        {
            _svc = service; //service object is automatically created when object of CreateModel is created
        }

        [BindProperty]
        public string WorkshopId { get; set; }

        [BindProperty]
        public WorkshopInfo CreateAWorkshop { get; set; }

        [BindProperty]
        public string MyMessage { get; set; }

        public void OnGet()
        {
            Guid guid = Guid.NewGuid();
            CreateAWorkshop.wsId = guid.ToString();
            WorkshopId = CreateAWorkshop.wsId;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (_svc.AddWorkshop(CreateAWorkshop))
                {
                    // Create session

                    //HttpContext.Session.SetString("SSName", MyEmployee.Name);
                    //HttpContext.Session.SetString("SSDept", MyEmployee.Department.ToString());
                    return RedirectToPage("Confirm");
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
