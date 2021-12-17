using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace YouthAtHeart.Models
{
    public class Test
    {
        public int Id { get; set; }

        [Required]
        public string test { get; set; }
    }
}
