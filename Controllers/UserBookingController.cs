using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using YouthAtHeart.Models;

namespace YouthAtHeart.Controllers
{
    public class UserBookingController : Controller
    {
        private readonly YouthAtHeartContext context;

        public UserBookingController(YouthAtHeartContext context)
        {
            this.context = context;
        }
        [Route("UserAddBooking/{WorkshopId}")]
        public IActionResult UserAddBooking(string WorkshopId)
        {
            var userRole = HttpContext.Session.GetString("SSRole");
            if (userRole == null && userRole != "student") //xl user role for user
                return Redirect("~/Login");
            Booking newbooking = new Booking();
            newbooking.workshopInfo = context.WorkshopInfo.Where(x => x.wsId.Equals(WorkshopId)).FirstOrDefault();
            newbooking.WorkshopId = WorkshopId;
            ViewData["message"] = "";
            return View("~/Pages/UserCreateBooking.cshtml", newbooking);
        }
        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        [HttpPost]
        [Route("UserCreateBooking")]
        public IActionResult UserCreateBooking(Booking newbooking)
        {
            var userRole = HttpContext.Session.GetString("SSRole");
            if (userRole == null && userRole != "student")
                return Redirect("~/Login");
            WorkshopInfo workshop = null;
            if (newbooking != null)
            {
                workshop = context.WorkshopInfo.Where(x => x.wsId.Equals(newbooking.WorkshopId)).FirstOrDefault();
                newbooking.workshopInfo = workshop;
            }
            ViewData["message"] = "";
            if (string.IsNullOrEmpty(newbooking.FirstName) || string.IsNullOrEmpty(newbooking.LastName) || string.IsNullOrEmpty(newbooking.Email) || string.IsNullOrEmpty(newbooking.PhoneNumber) || string.IsNullOrEmpty(newbooking.Comments))
            {
                ViewData["message"] = "Invalid input";
            }
            else if (newbooking.PhoneNumber.Length < 10)
            {
                ViewData["message"] = "Invalid phone number";
            }
            else if (!this.IsValidEmail(newbooking.Email))
            {
                ViewData["message"] = "Invalid Email";
            }
            else
            {
                newbooking.BookingAmount = (double)workshop.wsPrice;
                newbooking.BookingId = Guid.NewGuid().ToString();
                newbooking.CreatedDate = DateTime.Now;

                context.Booking.Add(newbooking);
                context.SaveChanges();
                ViewData["message"] = "Booking has been created successfully.";
                return View("~/Pages/UserCreateBookingPayment.cshtml", newbooking);

            }


            return View("~/Pages/UserCreateBooking.cshtml", newbooking);
        }

        [HttpPost]
        [Route("ConfirmBookingPayment")]
        public IActionResult ConfirmBookingPayment(Booking newbooking)
        {
            var userRole = HttpContext.Session.GetString("SSRole");
            if (userRole == null && userRole != "student")
                return Redirect("~/Login");
            WorkshopInfo workshop = null;
            if (newbooking != null)
            {
                workshop = context.WorkshopInfo.Where(x => x.wsId.Equals(newbooking.WorkshopId)).FirstOrDefault();
                newbooking.workshopInfo = workshop;
            }
            ViewData["message"] = "";
            if (string.IsNullOrEmpty(newbooking.NameOnCard) || string.IsNullOrEmpty(newbooking.CardNumber) || string.IsNullOrEmpty(newbooking.Cvv) || string.IsNullOrEmpty(newbooking.ExpiryDate) || string.IsNullOrEmpty(newbooking.Comments))
            {
                ViewData["message"] = "Invalid input";
            }
            else if (newbooking.CardNumber.Length != 16)
            {
                ViewData["message"] = "Invalid Card number";
            }
            else if (newbooking.Cvv.Length != 3)
            {
                ViewData["message"] = "Invalid CVV";
            }
            else
            {
                Booking existingbookingdetails = context.Booking.Where(x => x.BookingId.Equals(newbooking.BookingId)).FirstOrDefault();
                existingbookingdetails.NameOnCard = newbooking.NameOnCard;
                existingbookingdetails.CardNumber = newbooking.CardNumber;
                existingbookingdetails.Cvv = newbooking.Cvv;
                existingbookingdetails.ExpiryDate = newbooking.ExpiryDate;
                existingbookingdetails.Comments = newbooking.Comments;

                //Add these four lines to update bookings in workshop model
                var WorkshopObject = context.WorkshopInfo.Where(x => x.wsId.Equals(newbooking.WorkshopId)).FirstOrDefault();
                WorkshopObject.wsPresentAttendees = existingbookingdetails.NumberOfAttendees;
                context.WorkshopInfo.Update(WorkshopObject);
                context.SaveChanges();

                context.Booking.Update(existingbookingdetails);
                context.SaveChanges();
                ViewData["username"] = existingbookingdetails.FirstName + " " + existingbookingdetails.LastName;
                return View("~/Pages/BookingCompleted.cshtml", newbooking);

            }


            return View("~/Pages/UserCreateBooking.cshtml", newbooking);
        }


        [Route("UserViewBooking/{bookingId}")]
        public IActionResult UserViewBooking(string bookingId)
        {
            var userRole = HttpContext.Session.GetString("SSRole");
            if (userRole == null && userRole != "student")
                return Redirect("~/Login");
            Booking viewbooking = context.Booking.Where(x => x.BookingId.Equals(bookingId)).FirstOrDefault();
            viewbooking.workshopInfo = context.WorkshopInfo.Where(x => x.wsId.Equals(viewbooking.WorkshopId)).FirstOrDefault();
            viewbooking.WorkshopId = viewbooking.WorkshopId;
            ViewData["message"] = "";
            return View("~/Pages/UserViewBooking.cshtml", viewbooking);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
