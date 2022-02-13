using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YouthAtHeart.Services;
using YouthAtHeart.Models;

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
        public IActionResult OnGet(string name)
        {
            if (name == null)
            {
                return NotFound();
            }
            user = _svc.GetUserbyId(name);
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
                return Page();
            }

            if (_svc.UpdateUser(user) == true)
            {
                return RedirectToPage("Index");
            }
            else
                return BadRequest();
        }
    }
}
