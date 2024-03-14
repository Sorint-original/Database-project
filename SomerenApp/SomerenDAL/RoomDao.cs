using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class RoomDao : BaseDao
    {
        public List<Room> GetAllRooms()
        {
            string query = "SELECT * FROM Room";
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
                    RoomCode = (int)dr[dr.Table.Columns[0]],
                    RoomNumber = (int)dr[dr.Table.Columns[1]],
                    Floor = (int)dr[dr.Table.Columns[2]],
                    Building = dr[dr.Table.Columns[3]].ToString(),
                    NumberBeds = (int)dr[dr.Table.Columns[4]],
                    RoomType = (bool)dr[dr.Table.Columns[5]]
                };
                rooms.Add(room);
            }
            return rooms;
        }
    }
}
