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
using static System.Windows.Forms.LinkLabel;

namespace SomerenUI
{
    public partial class AddStudent : Form
    {
        public AddStudent(bool Add, int id = 0)
        {
            InitializeComponent();
            if (Add)
            {
                SetupAdd();
            }
            else
            {
                SetupUpdate(id);
            }
        }

        public void SetupAdd()
        {
            Updatepnl.Hide();
            UpdateB.Hide();
        }

        public void SetupUpdate(int id)
        {
            AddStudentB.Hide();
            RefreshStudentBox();
            if (id == 0)
            {
                StudentCB.SelectedIndex = 0;
            }
            else
            {
                //when it eneters update with a STUDENT selected
                StudentService studentService = new StudentService();
                List<Student> students = studentService.GetStudents();
                for (int i = 0; i < students.Count; i++)
                {
                    if (id == students[i].StudentNumber)
                    {
                        StudentCB.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void AddStudentB_Click(object sender, EventArgs e)
        {
            Student student = GetStudent(true);
            if (student != null)
            {
                StudentService studentService = new StudentService();
                studentService.AddStudent(student);
                this.Close();
            }
        }

        private Student GetStudent(bool add)
        {
            Student student = new Student();
            if (add == false)
            {
                student = StudentCB.SelectedItem as Student;
            }
            
            if(add == true)
            {
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
            }

            if (FirstNameTB.Text != "")
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

            if (add)
            {
                //Test if the student number is unique
                StudentService studentService = new StudentService();
                Student test = studentService.GetStudentById(student.StudentNumber);
                if (test != null)
                {
                    MessageBox.Show("There is already a student with this student number");
                    return null;
                }
            }

            //Test if Room exists

            RoomService roomService = new RoomService();
            Room room = roomService.GetRoomById(student.RoomCode);
            if (room == null)
            {
                MessageBox.Show("The student needs a valid room");
                return null;
            }

            return student;
        }

        public void RefreshStudentBox()
        {
            StudentCB.Items.Clear();
            StudentService studentService = new StudentService();
            List<Student> students = studentService.GetStudents();

            foreach (Student student in students)
            {
                StudentCB.Items.Add(student);
            }
        }

        private void StudentCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Student student = StudentCB.SelectedItem as Student;
            if (student != null)
            {
                FirstNameTB.Text = student.FirstName;
                LastNameTB.Text = student.LastName;
                PhoneNumberTB.Text = student.PhoneNumber;
                ClassTB.Text = student.Class;
                RoomCodeTB.Text = student.RoomCode.ToString();
            }
        }

        private void UpdateB_Click(object sender, EventArgs e)
        {

            Student student = GetStudent(false);
            if (student != null)
            {
                StudentService studentService = new StudentService();

                studentService.UpdateStudent(student);

                int auxiliary = StudentCB.SelectedIndex;
                StudentCB.Text = "";
                RefreshStudentBox();
                StudentCB.SelectedIndex = auxiliary;

            }
        }
    }
}
