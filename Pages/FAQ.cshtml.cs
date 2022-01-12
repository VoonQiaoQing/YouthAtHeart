using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace YouthAtHeart.Pages
{
    public class FAQModel : PageModel
    {
        [BindProperty]
        public List<Questions> AllQuestions { get; set; }
        public void OnGet()
        {
        }
    }
}
