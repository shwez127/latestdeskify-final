using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text;
using System.Threading.Tasks;
using DeskEntity.Model;
using Newtonsoft.Json;
using System;
using System.Security.Policy;

namespace DeskUI.Controllers
{
    public class BookingSeatController : Controller
    {
        private IConfiguration _configuration;

        public BookingSeatController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> AllBookingSeats()
        {
            IEnumerable<BookingSeat> bookingseatresult = null;
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBaseUrl"] + "BookingSeat/GetAllBookingSeats";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        bookingseatresult = JsonConvert.DeserializeObject<IEnumerable<BookingSeat>>(result);
                    }
                }
            }
            return View(bookingseatresult);
        }


        public IActionResult AddBookingSeat()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBookingSeat(BookingSeat bookseat)
        {

            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(bookseat), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "BookingSeat/AddSeatBooking";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Booking Seat Added!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> DeleteBookingSeat(int BookSeatId)
        {
            BookingSeat seat = new BookingSeat();
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "BookingSeat/GetSeatBookingById?bookingseatId=" + BookSeatId;

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        seat = JsonConvert.DeserializeObject<BookingSeat>(result);
                    }

                }
            }

            //Update booking


            seat.SeatStatus = 2;



            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(seat), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "BookingSeat/UpdateSeatBooking";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";


                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }
                }
            }
            TempData["SeatStatus"] = seat.SeatStatus;
            TempData.Keep();
            TempData["Count"] = Convert.ToInt32(TempData["Count"]) + 1;
            TempData.Keep();



            return View(seat);
        }

        //[HttpPost]
        //public async Task<IActionResult> DeleteBookingSeat(BookingSeat bookseat)

        //{

        //    BookingSeat bookingSeat1=new BookingSeat();

        //    // Updating Booking status

        //    bookingSeat1.SeatStatus = 2;






        //    using (HttpClient client = new HttpClient())
        //    {
        //        StringContent content = new StringContent(JsonConvert.SerializeObject(bookingSeat1), Encoding.UTF8, "application/json");
        //        string endPoint = _configuration["WebApiBaseUrl"] + "BookingSeat/UpdateSeatBooking";
        //        using (var response = await client.PutAsync(endPoint, content))
        //        {
        //            if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                ViewBag.status = "Ok";
                       

        //            }
        //            else
        //            {
        //                ViewBag.status = "Error";
        //                ViewBag.message = "Wrong Entries";
        //            }
        //        }
        //    }

        //    int bookingStatus  = Convert.ToInt32(TempData["SeatStatus"]);
        //    TempData.Keep();

            


        //    using (HttpClient client = new HttpClient())
        //    {
        //        string endPoint = _configuration["WebApiBaseUrl"] + "BookingSeat/DeleteSeatBooking?bookingseatId=" + bookseat.BookingSeatId;
        //        using (var response = await client.DeleteAsync(endPoint))
        //        {
        //            if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                ViewBag.status = "Ok";
        //                ViewBag.message = "BookingSeat details deleted successfully";
        //                TempData["Count"] = Convert.ToInt32(TempData["Count"]) + 1;
        //                TempData.Keep();
                        
        //            }
        //            else
        //            {
        //                ViewBag.status = "Error";
        //                ViewBag.message = "Wrong Entries";
        //            }
        //        }
        //    }
        //    return View();
        //}



        public async Task<IActionResult> EditBookingSeat(int BookSeatId)
        {
            BookingSeat seat = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "BookingSeat/GetSeatBookingById?bookingseatId=" + BookSeatId;

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        seat = JsonConvert.DeserializeObject<BookingSeat>(result);
                    }

                }
            }
            return View(seat);
        }

        [HttpPost]
        public async Task<IActionResult> EditBookingSeat(BookingSeat bookseat)

        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(bookseat), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "BookingSeat/UpdateSeatBooking";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "BookingSeat Updated!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }
                }
            }
            return View();
        }

    }
}

