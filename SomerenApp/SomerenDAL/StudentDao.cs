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
            string command = "DELETE FROM buys WHERE StudentNumber = @Id  ;DELETE FROM Student WHERE StudentNumber = @Id ;";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Id", ID);

            ExecuteEditQuery(command, sqlParameters);
        }

        public void AddStudent(Student student)
        {
            string command = "INSERT INTO Student VALUES (@StudentNumber, @FirstName, @SecondName, @Phone, @Class, @RoomCode)";
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@StudentNumber", student.StudentNumber);
            sqlParameters[1] = new SqlParameter("@FirstName", student.FirstName);
            sqlParameters[2] = new SqlParameter("@SecondName", student.LastName);
            sqlParameters[3] = new SqlParameter("@Phone", student.PhoneNumber);
            sqlParameters[4] = new SqlParameter("@Class", student.Class);
            sqlParameters[5] = new SqlParameter("@RoomCode", student.RoomCode);

            ExecuteEditQuery(command, sqlParameters);
        }

        public void UpdateStudent(Student student)
        {
            string command = "UPDATE  Student SET FirstName = @FirstName, LastName =  @SecondName, TelephoneNumber = @Phone, Class = @Class, RoomCode = @RoomCode WHERE StudentNumber = @StudentNumber";
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@StudentNumber", student.StudentNumber);
            sqlParameters[1] = new SqlParameter("@FirstName", student.FirstName);
            sqlParameters[2] = new SqlParameter("@SecondName", student.LastName);
            sqlParameters[3] = new SqlParameter("@Phone", student.PhoneNumber);
            sqlParameters[4] = new SqlParameter("@Class", student.Class);
            sqlParameters[5] = new SqlParameter("@RoomCode", student.RoomCode);

            ExecuteEditQuery(command, sqlParameters);
        }
    }
}