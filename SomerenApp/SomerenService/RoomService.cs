using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenService
{
    public class RoomService
    {
        private RoomDao roomDao;

        public RoomService()
        {
            roomDao = new RoomDao();
        }

        public List<Room> GetRooms()
        {
            List<Room> rooms = roomDao.GetAllRooms();
            return rooms;
        }

        public Room GetRoomById(int id)
        {
            return roomDao.GetRoomById(id);
        }
    }
}
