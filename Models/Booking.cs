using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YouthAtHeart.Models
{
    public class Booking
    {
        [Key]
        public string BookingId { get; set; }

       // [Required(ErrorMessage = "Please Login to continue")]
        public int CustomerId { get; set; }
        public string WorkshopId { get; set; }


        [Required(ErrorMessage = "Error in Cart, Please try again")]
        [DataType(DataType.Currency)]
        public decimal BookingAmount { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(75)]
        [RegularExpression(@"(\S)+", ErrorMessage = "Alphabets only.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(75)]
        [RegularExpression(@"(\S)+", ErrorMessage = "Alphabets only.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        //[DataType(DataType.PhoneNumber)]
        [StringLength(13, MinimumLength = 10)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email address required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Remarks { get; set; }

        [Required(ErrorMessage = "No.of attendees required")]
        [Range(1, 10, ErrorMessage = "Please Provide correct range")]
        public int NumberOfAttendees { get; set; }

        public int PaymentStatus { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string NameOnCard { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string ExpiryDate { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Cvv { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Comments { get; set; }

        [NotMapped]
        public WorkshopInfo workshopInfo { get; set; }


    }
} 
        