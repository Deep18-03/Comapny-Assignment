using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public interface IRoomRepository
    {
        Room GetRoom(int id);
        List<Room> GetAllRoom();
        string CreateRoom(Room model);
        string UpdateRoom(Room model);
        string DeleteRoom(int id);

    }
}
