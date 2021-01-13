using HMS.BAL.Interface;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HMS.Web_Api.Controllers
{
    public class BookingController : ApiController
    {
        private readonly IBookingManager _bookingManager;

        public BookingController(IBookingManager bookingManager)
        {
            _bookingManager=bookingManager;

        }

        // GET: api/Booking
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Booking/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Booking
        public IHttpActionResult Post([FromBody]Booking model)
        {
            var booking = _bookingManager.CreateBooking(model);
            return Ok(booking);
        }

        // PUT: api/Booking/5
        public IHttpActionResult Put([FromBody]Booking model)
        {
            var booking = _bookingManager.UpdateBooking(model);
            return Ok(booking);
        }

        // DELETE: api/Booking/5
        public string Delete(int id)
        {
            return _bookingManager.DeleteBooking(id);
        }
    }
}
