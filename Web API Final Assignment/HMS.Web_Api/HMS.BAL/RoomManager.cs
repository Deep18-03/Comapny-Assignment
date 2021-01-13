using HMS.BAL.Interface;
using HMS.DAL.Repository;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL
{
    public class RoomManager : IRoomManager
    {
        private readonly IRoomRepository _roomRepository;

        public RoomManager(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public string CreateRoom(Room model)
        {
            return _roomRepository.CreateRoom(model);
        }

        public string DeleteRoom(int id)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAllRoom()
        {
            return _roomRepository.GetAllRoom();
        }

        //public Room GetRoom()
        //{
        //    //Room room = new Room
        //    //{
        //    //    id = 7,
        //    //    RoomName = "ads"


        //    //};
        //    //return room;

        //    var room = _roomRepository.GetRoom();
        //    return room;
        //}

        public Room GetRoom(int id)
        {
            return _roomRepository.GetRoom(id);
        }

        public string UpdateRoom(Room model)
        {
            throw new NotImplementedException();
        }
    }
}
