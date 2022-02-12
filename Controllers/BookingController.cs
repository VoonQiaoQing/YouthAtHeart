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
        [Route("AddBooking")]
        public IActionResult AddBooking(string WorkshopId)
        {
            Booking newbooking = new Booking();
            newbooking.WorkshopId = WorkshopId;
            ViewData["message"] = "";
            return View("~/Pages/CreateBooking.cshtml",newbooking);
        }

        [HttpPost]
        [Route("CreateBooking")]


        public IActionResult CreateBooking(Booking newbooking)
        {
            if (ModelState.IsValid)
            {
                WorkshopInfo workshop = context.WorkshopInfo.Where(x => x.wsId.Equals(newbooking.WorkshopId)).FirstOrDefault();
                newbooking.BookingAmount = (decimal)workshop.wsPrice;
                newbooking.BookingId = Guid.NewGuid().ToString();
                newbooking.CreatedDate = DateTime.Now;

                context.Booking.Add(newbooking);
                context.SaveChanges();
                ViewData["message"] = "Booking has been created successfully.";
                     
            }

            return View("~/Pages/CreateBooking.cshtml", newbooking);
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
