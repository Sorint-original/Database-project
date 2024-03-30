using SomerenModel;
using SomerenService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void AddStudentB_Click(object sender, EventArgs e)
        {
            Student student = GetStudent();
        }

        private Student GetStudent()
        {
            Student student = new Student();

            if (SNumberTB.Text.Length == 6)
            {
                try
                {
                    student.StudentNumber = int.Parse(SNumberTB.Text);
                }
                catch
                {
                    MessageBox.Show("The student Number needs to be a integer");
                    return null;
                }
            }
            else
            {
                MessageBox.Show("The student needs a student number of 6 digits");
                return null;
            }

            if(FirstNameTB.Text != "")
            {
                student.FirstName = FirstNameTB.Text;
            }
            else
            {
                MessageBox.Show("The student needs a first name");
                return null;
            }

            if (LastNameTB.Text != "")
            {
                student.LastName = LastNameTB.Text;
            }
            else
            {
                MessageBox.Show("The student needs a last name");
                return null;
            }

            Regex regex = new Regex(@"^(^[0][1-9]\d{8}$)+$");
            Match match = regex.Match(PhoneNumberTB.Text);
            if (match.Success)
            {
                student.PhoneNumber = PhoneNumberTB.Text;
            }
            else
            {
                MessageBox.Show("The student needs a valid phone number");
                return null;
            }

            if (ClassTB.Text != "")
            {
                student.Class = ClassTB.Text;
            }
            else
            {
                MessageBox.Show("The student needs a class");
                return null;
            }

            if (RoomCodeTB.Text.Length > 0)
            {
                try
                {
                    student.RoomCode = int.Parse(RoomCodeTB.Text);
                }
                catch
                {
                    MessageBox.Show("The Room Code needs to be a integer");
                    return null;
                }
            }
            else
            {
                MessageBox.Show("The student needs a valid Room code");
                return null;
            }

           //Test if the student number is unique
           StudentService studentService = new StudentService();
           Student test = studentService.GetStudentById(student.StudentNumber);
            if (test != null)
            {
                MessageBox.Show("There is already a student with thisstudent number");
                return null;
            }

           //Test if Room exists

            RoomService roomService = new RoomService();
            Room room = roomService.GetRoomById(student.RoomCode);
            if(room == null)
            {
                MessageBox.Show("The student needs a valid room");
                return null;
            }

            return student;
        }


    }
}
