using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using YouthAtHeart.Models;
using YouthAtHeart.Services;

namespace YouthAtHeart.Pages
{
    public class FAQModel : PageModel
    {
        [BindProperty]
        public List<FAQ> AllQuestions { get; set; }
        private readonly ILogger<FAQModel> _logger;
        private FAQService _svc;
        public FAQModel(ILogger<FAQModel> logger ,FAQService service)
        {
            _logger = logger;
            _svc = service;
        }
        public void OnGet()
        {
            AllQuestions = _svc.GetAllQuestion();
        }
    }
}
