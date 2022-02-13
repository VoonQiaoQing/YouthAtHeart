using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YouthAtHeart.Services;
using YouthAtHeart.Models;
using Microsoft.AspNetCore.Http;

namespace YouthAtHeart.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly UserService _svc;
        public ProfileModel(UserService service)
        {
            _svc = service;
        }
        [BindProperty]
        public User MyUser { get; set; }
        public IActionResult OnGet(string id)
        {
            if (id != null)
            {
                MyUser = _svc.GetUserbyId(id);
                if (!String.IsNullOrEmpty(HttpContext.Session.GetString("SSRole")))
                {
                    MyUser.role = HttpContext.Session.GetString("SSRole");
                }
                return Page();
            }
            else
            {
                return RedirectToPage("Index");
            }
        }
    }
}
