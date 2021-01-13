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
    public class HotelController : ApiController
    {

        private readonly IHotelManager _hotelManager;

        public HotelController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;
        }

        // GET: api/Hotel
        public IHttpActionResult Get()
        {

            //var hotel= _hotelManager.GetHotel();

            // return Ok(hotel);
            var hotel = _hotelManager.GetAllHotel();
            return Ok(hotel);

        }

        // GET: api/Hotel/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Hotel
        public IHttpActionResult Post([FromBody]Hotel model)
        {
            var hotel = _hotelManager.CreateHotel(model);
            return Ok(hotel);
                
        }

      
    }
}
