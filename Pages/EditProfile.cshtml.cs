using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YouthAtHeart.Services;
using YouthAtHeart.Models;
using System;
using Microsoft.AspNetCore.Http;

namespace YouthAtHeart.Pages
{
    public class EditProfileModel : PageModel
    {
        private readonly UserService _svc;
        public EditProfileModel(UserService service)
        {
            _svc = service;
        }
        [BindProperty]
        public User user { get; set; }
        [BindProperty]
        public string MyMessage { get; set; }
        public IActionResult OnGet(string id)
        {
            if(id == null)
            {
                return NotFound();
            }
            user = _svc.GetUserbyId(id);
            //user.userId = Guid.NewGuid().ToString();
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("SSRole")))
            {
                user.role = HttpContext.Session.GetString("SSRole");
            }
            if (user == null)
            {
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            
            if (!ModelState.IsValid)
            {
                MyMessage = "Error";
                //return Page();
            }
            string age = user.age.ToString();
            user.age = age;

            if (_svc.UpdateUser(user) == true)
            {
                return RedirectToPage("Index");
            }
            else
                return BadRequest();
        }
    }
}
