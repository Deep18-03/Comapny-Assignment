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
    public class RoomController : ApiController
    {
        private readonly IRoomManager _roomManager;

        public RoomController(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }

        // GET: api/Room
        public IHttpActionResult Get()
        {
            var room = _roomManager.GetAllRoom();
            return Ok(room);
        }

        // GET: api/Room/5
        public IHttpActionResult Get(int id)
        {
            var room = _roomManager.GetRoom(id);
            return Ok(room);
        }

        // POST: api/Room
        public IHttpActionResult Post([FromBody]Room model)
        {
            var room= _roomManager.CreateRoom(model);
            return Ok(room);
        }

        // PUT: api/Room/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Room/5
        public void Delete(int id)
        {
        }
    }
}
