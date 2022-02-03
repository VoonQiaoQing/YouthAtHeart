using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YouthAtHeart.Models;

namespace YouthAtHeart.Pages
{
    public class TestFAQModel : PageModel
    {
        [BindProperty]
        public FAQ MyQuestions { get; set; }
        [BindProperty]
        public FAQ MyQuestion { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            var x = "";
            x = "hello";
        }
    }
}
