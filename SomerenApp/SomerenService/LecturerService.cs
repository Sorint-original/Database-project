using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenService
{
    public class LecturerService
    {
        private LecturerDao lecturerDao;

        public LecturerService()
        {
            lecturerDao = new LecturerDao();
        }
        public List<Lecturer> GetLecturers()
        {
            List<Lecturer> lecturers = lecturerDao.GetAllLecturers();
            return lecturers;
        }
        public void DeleteByID(int id)
        {
            lecturerDao.DeleteById(id);
        }





        public Lecturer GetLecturerById(int id)
        {

            
            Lecturer lecturer = lecturerDao.GetLecturerById(id);
            return lecturer;
        }


        public void AddLecturer(Lecturer lecturer)
        {
            lecturerDao.AddLecturer(lecturer);
        }

        public void UpdateLecturer(Lecturer lecturer)
        {
            lecturerDao.UpdateLecturer(lecturer);
        }

    }
}
