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
                   PhoneNumber= (string)dr["PhoneNumber"],
                   RoomCode = (int)dr["RoomCode"]

                };
                lecturers.Add(lecturer);
            }
            return lecturers;
        }
    }
}
