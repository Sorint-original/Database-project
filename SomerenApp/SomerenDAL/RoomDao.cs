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
                    RoomCode = (int)dr[dr.Table.Columns[0].ColumnName],
                    RoomNumber = (int)dr[dr.Table.Columns[1].ColumnName],
                    Floor = (int)dr[dr.Table.Columns[2].ColumnName],
                    Building = (string)dr[dr.Table.Columns[3].ColumnName],
                    NumberBeds = (int)dr[dr.Table.Columns[4].ColumnName],
                    RoomType = (bool)dr[dr.Table.Columns[5].ColumnName]
                };
                rooms.Add(room);
            }
            return rooms;
        }
    }
}
