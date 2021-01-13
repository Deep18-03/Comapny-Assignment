using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL.Interface
{
    public interface IRoomManager
    {
        Room GetRoom(int id);
        List<Room> GetAllRoom();
        string CreateRoom(Room model);
        string UpdateRoom(Room model);
        string DeleteRoom(int id);

    }
}
