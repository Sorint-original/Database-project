using SomerenService;
using SomerenModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
            ShowRoomsPanel();
        }

        private void ShowDashboardPanel()
        {
            // hide all other panels
            pnlStudents.Hide();
            pnlRooms.Hide();

            // show dashboard
            pnlDashboard.Show();
        }

        private void ShowStudentsPanel()
        {
            // hide all other panels
            pnlRooms.Hide();

            // show students
            pnlStudents.Show();

            try
            {
                // get and display all students
                List<Student> students = GetStudents();
                DisplayStudents(students);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the students: " + e.Message);
            }
        }

        private void ShowRoomsPanel()
        {

            // show students
            pnlRooms.Show();

            try
            {
                // get and display all students
                List<Room> rooms = GetRooms();
                DisplayRooms(rooms);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the rooms: " + e.Message);
            }
        }

        private List<Student> GetStudents()
        {
            StudentService studentService = new StudentService();
            List<Student> students = studentService.GetStudents();
            return students;
        }

        private List<Room> GetRooms()
        {
            RoomService roomService = new RoomService();
            List<Room> rooms = roomService.GetRooms();
            return rooms;
        }

        private void DisplayStudents(List<Student> students)
        {
            // clear the listview before filling it
            listViewStudents.Items.Clear();

            foreach (Student student in students)
            {
                ListViewItem li = new ListViewItem(student.StudentNumber.ToString());
                li.SubItems.Add(student.FirstName);
                li.SubItems.Add(student.LastName);
                li.SubItems.Add(student.PhoneNumber);
                li.SubItems.Add(student.Class);
                li.Tag = student;   // link student object to listview item
                listViewStudents.Items.Add(li);
            }
        }

        private void DisplayRooms(List<Room> rooms)
        {
            // clear the listview before filling it
            listViewRooms.Items.Clear();

            foreach (Room room in rooms)
            {
                ListViewItem li = new ListViewItem(room.RoomCode.ToString());
                li.SubItems.Add(room.RoomNumber.ToString());
                li.SubItems.Add(room.Floor.ToString());
                li.SubItems.Add(room.Building.ToString());
                li.SubItems.Add(room.NumberBeds.ToString());
                if (room.RoomType)
                {
                    li.SubItems.Add("Lecturer");
                }
                else
                {
                    li.SubItems.Add("Student");
                }
                li.Tag = room;   // link student object to listview item
                listViewStudents.Items.Add(li);
            }
        }

        private void dashboardToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            ShowDashboardPanel();
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStudentsPanel();
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRoomsPanel();
        }
    }
}