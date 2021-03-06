using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace YouthAtHeart.Models
{
    public class FAQ
    {
        [Key]
        public int UID { get;set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Question { get; set; }
        private string Answer { get; set; }
        
    }
}
