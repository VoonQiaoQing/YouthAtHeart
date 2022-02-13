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
    public class LoginModel : PageModel
    {
        private readonly Services.UserService _svc;
        public LoginModel(Services.UserService service)
        {
            _svc = service;
        }
        [BindProperty]
        public User user { get; set; }
        [BindProperty]
        public string MyMessage { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (user.username == "Admin")
                {
                    if (!_svc.UserExits("Admin"))
                    {
                        user.username = "Admin";
                        user.email = "admin@gmail.com";
                        user.password = "adminPass123";
                        user.role = "admin";
                        _svc.AddUser(user);
                        HttpContext.Session.SetString("userName", user.username);
                        HttpContext.Session.SetString("SSRole", user.role.ToString());
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        if (_svc.GetUserbyId(user.username) != null && _svc.GetUserbyId(user.username).password == user.password)
                        {
                            HttpContext.Session.SetString("userName", user.username);
                            HttpContext.Session.SetString("SSRole", user.role.ToString());
                            return RedirectToPage("Index");
                        }
                        else
                        {
                            MyMessage = "Invalid admin account.";
                        }
                    }
                }
                else
                {
                    if (!_svc.UserExits(user.username))
                    {
                        MyMessage = "This user did not have an account yet.";
                        return Page();
                    }
                    else
                    {
                        if (_svc.GetUserbyId(user.username) != null && _svc.GetUserbyId(user.username).password == user.password)
                        {
                            HttpContext.Session.SetString("userName", user.username);
                            var sessionId = HttpContext.Session.Id;
                            HttpContext.Session.SetString("SSRole", user.role.ToString());
                            HttpContext.Session.SetString("SSRole", user.role.ToString());

                            return RedirectToPage("Index");
                        }
                        else
                        {
                            MyMessage = "Invalid username or password";
                        }
                    }
                }
            }
            return Page();

        }
    }
}
