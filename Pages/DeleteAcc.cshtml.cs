using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YouthAtHeart.Models;
using YouthAtHeart.Services;

namespace YouthAtHeart.Pages
{
    public class DeleteAccModel : PageModel
    {
        private readonly UserService _svc;
        public DeleteAccModel(UserService service)
        {
            _svc = service;
        }
        [BindProperty]
        public User user { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            user = _svc.GetUserbyId(id);
            if (user == null)
            {
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            user = _svc.GetUserbyId(id);
            if (_svc.DeleteUser(user) == true)
            {
                return RedirectToPage("Index");
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
