using SomerenDAL;
using SomerenModel;
using System.Collections.Generic;

namespace SomerenService
{
    public class StudentService
    {
        private StudentDao studentDao;

        public StudentService()
        {
            studentDao = new StudentDao();
        }

        public List<Student> GetStudents()
        {
            List<Student> students = studentDao.GetAllStudents();
            return students;
        }

        public void DeleteByID(int id)
        {
            studentDao.DeleteById(id);
        }

        public Student GetStudentById(int id) {
            return studentDao.GetStudentById(id);
        }

        public void AddStudent(Student student)
        {
            studentDao.AddStudent(student);
        }

        public void UpdateStudent(Student student)
        {
            studentDao.UpdateStudent(student);
        }
    }
}