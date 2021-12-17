using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace YouthAtHeart.Models
{
    public class HomeInfo
    {
        [Required, Key]
        public string homeId { get; set; }

        [Required(ErrorMessage = "Please insert overview about Youth at Heart.")]
        public string homeOverview { get; set; }

        [Required(ErrorMessage = "No home cover image uploaded.")]
        public string homeImage { get; set; }
    }
}
