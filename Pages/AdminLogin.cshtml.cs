using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YouthAtHeart.Models;

namespace YouthAtHeart.Pages
{
    public class AdminLoginModel : PageModel
    {
        private readonly Services.UserService _svc;
        public AdminLoginModel(Services.UserService service)
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
                if (!_svc.UserExits("Admin"))
                {
                    user.username = "Admin";
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
            return Page();
        }
    }
}
