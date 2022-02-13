using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YouthAtHeart.Services;

namespace YouthAtHeart.Pages
{
    public class EditProfileModel : PageModel
    {
        private readonly UserService _svc;
        public EditProfileModel(UserService service)
        {
            _svc = service;
        }
        public void OnGet()
        {
        }
    }
}
