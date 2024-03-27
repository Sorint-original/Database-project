using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class StudentDao : BaseDao
    {
        public List<Student> GetAllStudents()
        {
            string query = "SELECT StudentNumber, FirstName, LastName, TelephoneNumber, Class, RoomCode  FROM Student";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Student> ReadTables(DataTable dataTable)
        {
            List<Student> students = new List<Student>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Student student = new Student()
                {
                    StudentNumber = (int)dr["StudentNumber"],
                    FirstName = (string)dr["FirstName"],
                    LastName = (string)dr["LastName"],
                    PhoneNumber = (string)dr["TelephoneNumber"],
                    Class = (string)dr["Class"],
                    RoomCode = (int)dr["RoomCode"]
                };
                students.Add(student);
            }
            return students;
        }

        public Student GetStudentById(int studentNumber)
        {
            string query = "SELECT StudentNumber, FirstName, LastName, TelephoneNumber, Class, RoomCode FROM Student WHERE StudentNumber = @studentNumber";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@studentNumber", studentNumber);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters))[0];
        }
    }
}