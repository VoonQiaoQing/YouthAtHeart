using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace YouthAtHeart.Models
{
    public class WorkshopInfo
    {
        [Required, Key]
        public string wsId { get; set; }

        [Required(ErrorMessage = "No cover image uploaded.")]
        public string wsCoverImage { get; set; }

        [Required(ErrorMessage = "No workshop environment image uploaded.")]
        public string wsEnvImage { get; set; }

        [Required(ErrorMessage = "Please insert name.")]
        public string wsName { get; set; }

        [Required(ErrorMessage = "Please insert main information.")]
        public string wsMainInfo { get; set; }

        public string wsExtraInfo { get; set; }

        [Required(ErrorMessage = "Please choose workshop type.")]
        public string wsType { get; set; }

        [Required(ErrorMessage = "Please choose location type.")]
        public string wsLocationType { get; set; }

        [Required(ErrorMessage = "Please insert location details.")]
        public string wsLocationDetails { get; set; }

        [Required(ErrorMessage = "Please insert lesson schedule.")]
        public string wsLessonSchedule { get; set; }

        [Required(ErrorMessage = "Please choose start registration date."), DataType(DataType.Date)]
        public DateTime regStartDate { get; set; }

        [Required(ErrorMessage = "Please choose end registration date."), DataType(DataType.Date)]
        public DateTime regEndDate { get; set; }

        [Required(ErrorMessage = "Please choose date of first lesson."), DataType(DataType.Date)]
        public DateTime firstLesDate { get; set; }

        [Required(ErrorMessage = "Please choose date of last lesson."), DataType(DataType.Date)]
        public DateTime endLesDate { get; set; }

        [Required(ErrorMessage = "Please insert lesson price.")]
        public Double wsPrice { get; set; }

        [Required(ErrorMessage = "Please insert total attendees no.")]
        public int wsTotalAttendees { get; set; }

        [Required(ErrorMessage = "Please insert workshop rating.")]
        public Double wsRating { get; set; }

        public DateTime dateCreated { get; set; }

        public DateTime dateUpdated { get; set; }

        [Required, Key]
        public string teacherId { get; set; }
    }
}
