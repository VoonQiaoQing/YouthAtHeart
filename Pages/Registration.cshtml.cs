using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YouthAtHeart.Models;

namespace YouthAtHeart.Pages
{
    public class RegistrationModel : PageModel
    {
        private readonly Services.UserService _svc;
        public RegistrationModel(Services.UserService service)
        {
            _svc = service;
        }
        [BindProperty]
        public User MyUser { get; set; }
        [BindProperty]
        public string MyMessage { get; set; }
        [BindProperty]
        public string Password2 { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (MyUser.password == Password2)
                {
                    if (_svc.AddUser(MyUser))
                    {
                        return RedirectToPage("Login");
                    }
                    else
                    {
                        MyMessage = "This account already exist!";
                        return Page();
                    }
                }
                else
                {
                    MyMessage = "Password did not match!";
                    return Page();
                }
                
            }
            return Page();
        }
    }
}
