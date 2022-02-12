using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace YouthAtHeart.Models
{
    public class WorkshopInfo
    {
        //private static string guidToStr;

        public WorkshopInfo()
        {
            Guid guid = Guid.NewGuid();
            wsId = guid.ToString("D");

            wsRatingAvg = 0;
            wsRatingTotal = 0;

            teacherId = "Temp Value";
            
            wsPresentAttendees = 0;

            dateCreated = DateTime.Now;
            dateUpdated = DateTime.Now;
        }

        [Required, Key]
        public string wsId { get; set; }
        public string wsCoverImage { get; set; }

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

        [Required(ErrorMessage = "Please insert No. of lessons you will conduct.")]
        public int wsNoOfLessons { get; set; }

        [Required(ErrorMessage = "Please insert lesson schedule.")]
        public string wsLessonSchedule { get; set; }

        [Required(ErrorMessage = "Please choose start registration date."), DataType(DataType.DateTime)]
        public DateTime regStartDate { get; set; }

        [Required(ErrorMessage = "Please choose end registration date."), DataType(DataType.DateTime)]
        public DateTime regEndDate { get; set; }

        [Required(ErrorMessage = "Please choose date of first lesson."), DataType(DataType.DateTime)]
        public DateTime firstLesDate { get; set; }

        [Required(ErrorMessage = "Please choose date of last lesson."), DataType(DataType.DateTime)]
        public DateTime endLesDate { get; set; }

        [Required(ErrorMessage = "Please insert lesson price."), DataType(DataType.Currency)]
        public Double wsPrice { get; set; }

        public int wsPresentAttendees { get; set; }

        [Required(ErrorMessage = "Please insert total attendees no.")]
        public int wsTotalAttendees { get; set; }

        public Double wsRatingAvg { get; set; }
        public Double wsRatingTotal { get; set; }

        public DateTime dateCreated { get; set; }
        public DateTime dateUpdated { get; set; }

        public string teacherId { get; set; }
    }
}
