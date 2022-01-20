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
        public IActionResult OnGet()
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("userName")))
            {
                MyUser = _svc.GetUserbyId(HttpContext.Session.GetString("userName"));

            }
            else
            {
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
