﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace YouthAtHeart.Models
{
    public class Registration
    {
        [Required, Key]
        public string userId { get; set; }

        [Required(ErrorMessage ="Please enter your username")]
        public string username { get; set; }

        [Required(ErrorMessage ="Please enter your email")]
        public string email { get; set; }

        [Required(ErrorMessage ="Please enter your password")]
        public string password { get; set; }

    }
}