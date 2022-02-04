using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YouthAtHeart.Models;
using YouthAtHeart.Services;

namespace YouthAtHeart.Pages
{
    public class TestFAQModel : PageModel
    {
        [BindProperty]
        public FAQ MyQuestions { get; set; }
        private readonly Services.FAQService _svc;
        public TestFAQModel(FAQService service)
        {
            _svc = service;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (_svc.AddQuestion(MyQuestions))
                {
                    //HttpContext.Session.SetString("SSEmail", MyQuestion.Email);
                    //HttpContext.Session.SetString("SSQuestion", MyQuestion.Question);
                    return RedirectToPage("FAQConfirmation");
                }
            }
            return Page();
        }
    }
}
