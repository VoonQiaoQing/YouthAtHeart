using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YouthAtHeart.Models;

namespace YouthAtHeart.Pages
{
    public class FAQModel : PageModel
    {
        [BindProperty]
        public List<FAQ> AllQuestions { get; set; }
        public void OnGet()
        {
        }
    }
}
