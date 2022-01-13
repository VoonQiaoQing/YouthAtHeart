using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public void OnGet()
        {
        }
    }
}
