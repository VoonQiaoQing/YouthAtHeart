using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace YouthAtHeart.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Enter your username")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Enter your password")]
        public string password { get; set; }
    }
}
