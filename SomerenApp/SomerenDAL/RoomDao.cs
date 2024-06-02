using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace SomerenDAL
{
    public class RoomDao : BaseDao
    {
        public List<Room> GetAllRooms()
        {
            string query = "SELECT RoomCode, RoomNumber, Floor, Building, NumberBeds, RoomType FROM Room;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Room> ReadTables(DataTable dataTable)
        {
            List<Room> rooms = new List<Room>();

            foreach (DataRow dr in dataTable.Rows)
            {
                    Room room = new Room()
                {
                    RoomCode = (int)dr["RoomCode"],
                    RoomNumber = (int)dr["RoomNumber"],
                    Floor = (int)dr["Floor"],
                    Building = (string)dr["Building"],
                    NumberBeds = (int)dr["NumberBeds"],
                    RoomType = (bool)dr["RoomType"]
                };
                rooms.Add(room);
            }
            return rooms;
        }

       public Room GetRoomById (int id)
        {
            string query = "SELECT RoomCode, RoomNumber, Floor, Building, NumberBeds, RoomType FROM Room WHERE RoomCode = @RoomCode";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@RoomCode", id);
            try
            {
                return ReadTables(ExecuteSelectQuery(query, sqlParameters))[0];
            }
            catch
            {
                return null;
            }
        }
    }
}