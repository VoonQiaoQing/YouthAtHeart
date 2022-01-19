using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouthAtHeart.Models;
using YouthAtHeart.Services;

namespace YouthAtHeart.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Test> alltest { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly TestService _svc;

        public IndexModel(ILogger<IndexModel> logger, TestService service)
        {
            _logger = logger;
            _svc = service;
        }

        public void OnGet()
        {
            alltest = _svc.GetAllTest();
        }
    }
}