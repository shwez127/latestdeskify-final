
namespace DeskUI.Controllers
{
    using DeskEntity.Model;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    
        public class ReportController : Controller
        {
            private IConfiguration _configuration;
            public static List<BookingSeat> bookings1 = new List<BookingSeat>();
            public static List<BookingSeat> bookings = new List<BookingSeat>();



            public ReportController(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public IActionResult Index()
            {
                bookings1 = null;
                return View();
            }

            public IActionResult GetCustomDates()
            {
                return View();
            }


            [HttpPost]
            public async Task<IActionResult> GetCustomDates(BookingSeat booking)
            {
                bookings1.Clear();

                int d = Convert.ToInt32(booking.FromDate.Day);
                int e = Convert.ToInt32(booking.ToDate.Day);
                int j = 0;

                for (int i = d; i <= e; i++)
                {
                    List<BookingSeat> bookings = null;
                    DateTime date1 = booking.FromDate.AddDays(j);
                    string date2 = date1.ToString("yyyy-MM-dd");
                    using (HttpClient client = new HttpClient())
                    {
                        string endPoint = _configuration["WebApiBaseUrl"] + "BookingSeat/GetBookingsByDate?date1=" + date2;
                        TempData.Keep();
                        using (var response = await client.GetAsync(endPoint))
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                var result = await response.Content.ReadAsStringAsync();
                                //It will deserilize the object in the form of JSON
                                bookings = JsonConvert.DeserializeObject<List<BookingSeat>>(result);
                            }
                        }
                    }
                    j++;
                    foreach (var item in bookings)
                    {
                        item.FromDate = date1;
                        bookings1.Add(item);
                    }
                }
                return RedirectToAction("GetReportByWeek", "Report");
            }

            public async Task<IActionResult> GetReportByWeek()
            {
                List<Employee> employees = null;
                using (HttpClient client = new HttpClient())
                {
                    // LocalHost Adress in endpoint
                    string endPoint = _configuration["WebApiBaseUrl"] + "Employee/GetAllEmployees";
                    using (var response = await client.GetAsync(endPoint))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var result = await response.Content.ReadAsStringAsync();
                            //It will deserilize the object in the form of JSON
                            employees = JsonConvert.DeserializeObject<List<Employee>>(result);
                        }
                    }
                }
                var tupeluser = new Tuple<List<Employee>, List<BookingSeat>>(employees, bookings1);
                return View(tupeluser);
            }
        }
}
    
