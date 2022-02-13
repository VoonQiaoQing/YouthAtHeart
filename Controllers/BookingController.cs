using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouthAtHeart.Models;

namespace YouthAtHeart.Controllers
{
    public class BookingController : Controller
    {
        private readonly YouthAtHeartContext context;

        public BookingController(YouthAtHeartContext context)
        {
            this.context = context;
        }
        [Route("AddBooking/{WorkshopId}")]
        public IActionResult AddBooking(string WorkshopId)
        {
            Booking newbooking = new Booking();
            newbooking.workshopInfo = context.WorkshopInfo.Where(x => x.wsId.Equals(WorkshopId)).FirstOrDefault();
            newbooking.WorkshopId = WorkshopId;
            ViewData["message"] = "";
            return View("~/Pages/CreateBooking.cshtml", newbooking);
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
        [Route("AddBooking")]
        public IActionResult CreateBooking(Booking newbooking)
        {
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
            }


            return View("~/Pages/CreateBooking.cshtml", newbooking);
        }

        [Route("AllBookings/{wsId}")]
        public IActionResult AllBookings(string wsId)
        {
            IList<Booking> allbookings = null;
            ViewBag.WorkshopId = wsId;
            if (!string.IsNullOrEmpty(wsId))
            {
                allbookings = context.Booking.Where(x => x.WorkshopId.Equals(wsId)).ToList();

            }
            return View("~/Pages/AllBookings.cshtml", allbookings);
        }

        [Route("EditBooking/{bookingId}")]
        public IActionResult EditBooking(string bookingId)
        {
            Booking updatebooking = context.Booking.Where(x => x.BookingId.Equals(bookingId)).FirstOrDefault();
            updatebooking.workshopInfo = context.WorkshopInfo.Where(x => x.wsId.Equals(updatebooking.WorkshopId)).FirstOrDefault();
            updatebooking.WorkshopId = updatebooking.WorkshopId;
            ViewData["message"] = "";
            return View("~/Pages/EditBooking.cshtml", updatebooking);
        }

        [HttpPost]
        [Route("EditBooking")]
        public IActionResult EditBooking(Booking updatedbookingdetails)
        {
            if (updatedbookingdetails != null)
            {
                updatedbookingdetails.workshopInfo = context.WorkshopInfo.Where(x => x.wsId.Equals(updatedbookingdetails.WorkshopId)).FirstOrDefault();
            }
            ViewData["message"] = "";
            if (string.IsNullOrEmpty(updatedbookingdetails.FirstName) || string.IsNullOrEmpty(updatedbookingdetails.LastName) || string.IsNullOrEmpty(updatedbookingdetails.Email) || string.IsNullOrEmpty(updatedbookingdetails.PhoneNumber) || string.IsNullOrEmpty(updatedbookingdetails.Comments))
            {
                ViewData["message"] = "Invalid input";
            }
            else if (updatedbookingdetails.PhoneNumber.Length < 10)
            {
                ViewData["message"] = "Invalid phone number";
            }
            else if (!this.IsValidEmail(updatedbookingdetails.Email))
            {
                ViewData["message"] = "Invalid Email";
            }
            else
            {
                Booking toUpdate = context.Booking.Where(x => x.BookingId.Equals(updatedbookingdetails.BookingId)).FirstOrDefault();
                toUpdate.FirstName = updatedbookingdetails.FirstName;
                toUpdate.LastName = updatedbookingdetails.LastName;
                toUpdate.PhoneNumber = updatedbookingdetails.PhoneNumber;
                toUpdate.Email = updatedbookingdetails.Email;
                toUpdate.Comments = updatedbookingdetails.Comments;


                context.Booking.Update(toUpdate);
                context.SaveChanges();
                ViewData["message"] = "Booking has been updated successfully.";
            }

            return View("~/Pages/EditBooking.cshtml", updatedbookingdetails);
        }
        
        [Route("ViewBooking/{bookingId}")]
        public IActionResult ViewBooking(string bookingId)
        {
            Booking viewbooking = context.Booking.Where(x => x.BookingId.Equals(bookingId)).FirstOrDefault();
            viewbooking.workshopInfo = context.WorkshopInfo.Where(x => x.wsId.Equals(viewbooking.WorkshopId)).FirstOrDefault();
            viewbooking.WorkshopId = viewbooking.WorkshopId;
            ViewData["message"] = "";
            return View("~/Pages/EditBooking.cshtml", viewbooking);
        }

        [HttpPost]
        [Route("ViewBooking")]
        public IActionResult ViewBooking(Booking updatedbookingdetails)
        {
            if (updatedbookingdetails != null)
            {
                updatedbookingdetails.workshopInfo = context.WorkshopInfo.Where(x => x.wsId.Equals(updatedbookingdetails.WorkshopId)).FirstOrDefault();
            }
            ViewData["message"] = "";
            if (string.IsNullOrEmpty(updatedbookingdetails.FirstName) || string.IsNullOrEmpty(updatedbookingdetails.LastName) || string.IsNullOrEmpty(updatedbookingdetails.Email) || string.IsNullOrEmpty(updatedbookingdetails.PhoneNumber) || string.IsNullOrEmpty(updatedbookingdetails.Comments))
            {
                ViewData["message"] = "Invalid input";
            }
            else if (updatedbookingdetails.PhoneNumber.Length < 10)
            {
                ViewData["message"] = "Invalid phone number";
            }
            else if (!this.IsValidEmail(updatedbookingdetails.Email))
            {
                ViewData["message"] = "Invalid Email";
            }
            else
            {
                Booking toUpdate = context.Booking.Where(x => x.BookingId.Equals(updatedbookingdetails.BookingId)).FirstOrDefault();
                toUpdate.FirstName = updatedbookingdetails.FirstName;
                toUpdate.LastName = updatedbookingdetails.LastName;
                toUpdate.PhoneNumber = updatedbookingdetails.PhoneNumber;
                toUpdate.Email = updatedbookingdetails.Email;
                toUpdate.Comments = updatedbookingdetails.Comments;


                context.Booking.Update(toUpdate);
                context.SaveChanges();
               
            }

            return View("~/Pages/ViewBooking.cshtml", updatedbookingdetails);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
