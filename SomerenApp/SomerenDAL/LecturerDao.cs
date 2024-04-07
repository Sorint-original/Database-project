using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SomerenModel;
using System.IO;

namespace SomerenDAL
{
    public class LecturerDao : BaseDao
    {
        public List<Lecturer> GetAllLecturers()
        {
            string query = "SELECT LecturerId, FirstName, LastName, TelephoneNumber, Age, RoomCode FROM Lecturer";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Lecturer> ReadTables(DataTable dataTable)
        {
            List<Lecturer> lecturers = new List<Lecturer>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Lecturer lecturer = new Lecturer()
                {
                    LecturerId = (int)dr["LecturerId"],
                    FirstName = (string)dr["FirstName"],
                    LastName = (string)dr["LastName"],
                    Age = (int)dr["Age"],
                   PhoneNumber= (string)dr["TelephoneNumber"],
                   RoomCode = (int)dr["RoomCode"]

                };
                lecturers.Add(lecturer);
            }
            return lecturers;
        }

        private Lecturer ReadTable(DataTable dataTable)
        {
            Lecturer lecturer = new Lecturer()
            {
                LecturerId = (int)dataTable.Rows[0]["LecturerId"],
                FirstName = (string)dataTable.Rows[0]["FirstName"],
                LastName = (string)dataTable.Rows[0]["LastName"],
                Age = (int)dataTable.Rows[0]["Age"],
                PhoneNumber = (string)dataTable.Rows[0]["TelephoneNumber"],
                RoomCode = (int)dataTable.Rows[0]["RoomCode"]
            };
            return lecturer;
        }

        public Lecturer GetLecturerById(int id)
        {
            string query = "SELECT LecturerId, FirstName, LastName, TelephoneNumber, Age, RoomCode FROM Lecturer WHERE LecturerId = @id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", id);
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }
    }
}
