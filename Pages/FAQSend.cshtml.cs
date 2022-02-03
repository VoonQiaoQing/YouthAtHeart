using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YouthAtHeart.Models;
using Microsoft.Extensions.Logging;
using YouthAtHeart.Services;
using Microsoft.AspNetCore.Http;

namespace YouthAtHeart.Pages
{
    public class FAQSendModel : PageModel
    {
        [BindProperty]
        public FAQ MyQuestion { get; set; }
        private readonly ILogger<IndexModel> _logger;
        private FAQService _svc;
        public FAQSendModel(ILogger<IndexModel> logger, FAQService service)
        {
            _svc = service;
            _logger = logger;
        }
        [BindProperty]
        public FAQ MyQuestions { get; set; }
        
        public void OnGet()
        {
        }
        public IActionResult onPost()
        {
            if (ModelState.IsValid)
            {
                if (_svc.AddQuestion(MyQuestions))
                {
                    HttpContext.Session.SetString("SSEmail", MyQuestion.Email);
                    HttpContext.Session.SetString("SSQuestion", MyQuestion.Question);
                    return RedirectToPage("FAQConfirmation");
                }
            }
            return Page();
        }
    }
}
