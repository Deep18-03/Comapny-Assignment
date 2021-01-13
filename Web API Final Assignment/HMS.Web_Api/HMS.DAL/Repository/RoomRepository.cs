using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private Database.dbHMSEntities _dbContext;

        public RoomRepository()
        {
            _dbContext = new Database.dbHMSEntities();
        }
        public string CreateRoom(Room model)
        {
            try
            {
                if (model != null)
                {
                    Database.Room entity = new Database.Room();

                    entity.HotelId = model.HotelId;
                    entity.RoomName = model.RoomName;
                    entity.RoomCategory = model.RoomCategory;
                    entity.RoomPrice = model.RoomPrice;
                    entity.CreatedBy = model.CreatedBy;
                    entity.CreatedDate = DateTime.Now;

                    _dbContext.Rooms.Add(entity);
                    _dbContext.SaveChanges();

                    return "Successfully Added";
                }
                return "Model is null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteRoom(int id)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAllRoom()
        {
            var entities = _dbContext.Rooms.OrderBy(x=>x.RoomPrice).ToList();
            List<Room> list = new List<Room>() ;
            if(entities != null)
            {
                foreach(var item in entities)
                {
                    Room room = new Room();

                    room.id = item.id;
                    room.RoomName = item.RoomName;
                    room.HotelId = item.HotelId;
                    room.RoomCategory = item.RoomCategory;
                    room.RoomPrice = item.RoomPrice;
                    room.CreatedBy = item.CreatedBy;
                    room.CreatedDate = item.CreatedDate;
                    room.UpdatedBy = item.UpdatedBy;
                    room.UpdatedDate = item.UpdatedDate;

                    list.Add(room);
                }
            }
            return list;
        }

        //public Room GetRoom()
        //{
        //    Room room = new Room
        //    {
        //        id = 7,
        //        RoomName = "ads"


        //    };
        //    return room;
        //}

        public Room GetRoom(int id)
        {
            var entity = _dbContext.Rooms.Find(id);

            Room room = new Room();

            room.id = entity.id;
            room.RoomName = entity.RoomName;
            room.HotelId = entity.HotelId;
            room.RoomCategory = entity.RoomCategory;
            room.RoomPrice = entity.RoomPrice;
            room.CreatedBy = entity.CreatedBy;
            room.CreatedDate = entity.CreatedDate;
            room.UpdatedBy = entity.UpdatedBy;
            room.UpdatedDate = entity.UpdatedDate;

            return room;

        }

        public string UpdateRoom(Room model)
        {
            throw new NotImplementedException();
        }
    }
}
