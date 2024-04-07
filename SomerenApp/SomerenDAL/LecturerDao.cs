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

        public Lecturer GetLecturerById(int Id)
        {
            string query = "SELECT LecturerId, FirstName, LastName, Age, TelephoneNumber, RoomCode FROM Lecturer WHERE LecturerId = @lecturerId";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@lecturerId", Id);
            try
            {
                return ReadTables(ExecuteSelectQuery(query, sqlParameters))[0];
            }
            catch
            {
                return null;
            }
        }

        public void DeleteById(int ID)
        {
            string command = "DELETE FROM supervises WHERE LecturerID = @Id  ;DELETE FROM lecturer WHERE LecturerId = @Id ;";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Id", ID);

            ExecuteEditQuery(command, sqlParameters);
        }
        public void AddLecturer(Lecturer lecturer)
        {
            string command = "INSERT INTO Lecturer VALUES (@LecturerId, @FirstName, @SecondName, @Age, @TelephoneNumber, @RoomCode)";
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@LecturerId", lecturer.LecturerId);
            sqlParameters[1] = new SqlParameter("@FirstName", lecturer.FirstName);
            sqlParameters[2] = new SqlParameter("@SecondName", lecturer.LastName);
            sqlParameters[3] = new SqlParameter("@Age", lecturer.Age);
            sqlParameters[4] = new SqlParameter("@TelephoneNumber", lecturer.PhoneNumber);
            sqlParameters[5] = new SqlParameter("@RoomCode", lecturer.RoomCode);

            ExecuteEditQuery(command, sqlParameters);
        }

        public void UpdateLecturer(Lecturer lecturer)
        {
            string command = "UPDATE  Lecturer SET FirstName = @FirstName, LastName =  @SecondName, Age = @Age, TelephoneNumber = @TelephoneNumber, RoomCode = @RoomCode WHERE LecturerId = @LecturerId";
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@LecturerId", lecturer.LecturerId);
            sqlParameters[1] = new SqlParameter("@FirstName", lecturer.FirstName);
            sqlParameters[2] = new SqlParameter("@SecondName", lecturer.LastName);
            sqlParameters[3] = new SqlParameter("@Age", lecturer.Age);
            sqlParameters[4] = new SqlParameter("@TelephoneNumber", lecturer.PhoneNumber);
            sqlParameters[5] = new SqlParameter("@RoomCode", lecturer.RoomCode);

            ExecuteEditQuery(command, sqlParameters);
        }
    }
}
