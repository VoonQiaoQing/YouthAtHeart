using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouthAtHeart.Models
{
    public class Questions
    {
        public string Question { get; set; }
        private string Answer { get; set; }
        public string Email { get; set; }
    }
}
