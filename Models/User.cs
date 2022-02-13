using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace YouthAtHeart.Models
{
    public class User
    {
        
        [Key]
        public string userId { get; set; }

        [Required(ErrorMessage = "Please enter your username")]
        public string username { get; set; }

        
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter your password")] // make strong password requirements
        public string password { get; set; }

        public string role { get; set; }
        public string age { get; set; }

        public string preferred { get; set; }

        //[Required(ErrorMessage = "Your password does not match")]
        // public string confirmPass { get; set; }
    }
}
