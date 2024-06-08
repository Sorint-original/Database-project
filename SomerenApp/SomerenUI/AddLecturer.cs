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
    public partial class AddLecturer : Form
    {
        public AddLecturer(bool Add, int id = 0)
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
            UpdateLpnl.Hide();
            UpdateLecturerB.Hide();
        }

        public void SetupUpdate(int id)
        {
            addLecturerB.Hide();
            RefreshLecturerBox();
            if (id == 0)
            {
                lecturerCB.SelectedIndex = 0;
            }
            else
            {
                //when it eneters update with a Lecturer selected
                LecturerService lecturerService = new LecturerService();
                List<Lecturer> lecturers = lecturerService.GetLecturers();
                for (int i = 0; i < lecturers.Count; i++)
                {
                    if (id == lecturers[i].LecturerId)
                    {
                        lecturerCB.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void lectulerCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lecturer lecturer = lecturerCB.SelectedItem as Lecturer;
            if (lecturer != null)
            {
                FirstNameT.Text = lecturer.FirstName;
                LastNameT.Text = lecturer.LastName;
                NumberT.Text = lecturer.PhoneNumber;
                AgeT.Text = lecturer.Age.ToString();
                RoomCodeT.Text = lecturer.RoomCode.ToString();
            }
        }

        private void addLectureB_Click(object sender, EventArgs e)
        {
            Lecturer lecturer = GetLecturer(true);
            if (lecturer != null)
            {
                LecturerService lecturerService = new LecturerService();

                lecturerService.AddLecturer(lecturer);
                this.Close();
            }
        }

        private Lecturer GetLecturer(bool add)
        {
            Lecturer lecturer = new Lecturer();
            if (add == false)
            {
                lecturer = lecturerCB.SelectedItem as Lecturer;
            }

            if (add == true)
            {
                if (LecturerIdTB.Text.Length == 2)
                {
                    try
                    {
                        lecturer.LecturerId = int.Parse(LecturerIdTB.Text);
                    }
                    catch
                    {
                        MessageBox.Show("The lecturer Id needs to be a integer");
                        return null;
                    }
                }
                else
                {
                    MessageBox.Show("The lecturer needs a lecturer Id of 2 digits");
                    return null;
                }
            }

            if (FirstNameT.Text != "")
            {
                lecturer.FirstName = FirstNameT.Text;
            }
            else
            {
                MessageBox.Show("The lecturer needs a first name");
                return null;
            }

            if (LastNameT.Text != "")
            {
                lecturer.LastName = LastNameT.Text;
            }
            else
            {
                MessageBox.Show("The lecturer needs a last name");
                return null;
            }

            Regex regex = new Regex(@"^(^[0][1-9]\d{8}$)+$");
            Match match = regex.Match(NumberT.Text);
            if (match.Success)
            {
                lecturer.PhoneNumber = NumberT.Text;
            }
            else
            {
                MessageBox.Show("The lecturer needs a valid phone number");
                return null;
            }

            if (int.TryParse(AgeT.Text, out int age))
            {
                if (age >= 18 && age <= 80)
                {
                    lecturer.Age = age;
                }
                else
                {
                    MessageBox.Show("The lecturer's age must be between 18 and 80.");
                    return null;
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid integer age.");
                return null;
            }


            if (RoomCodeT.Text.Length > 0)
            {
                try
                {
                    lecturer.RoomCode = int.Parse(RoomCodeT.Text);
                }
                catch
                {
                    MessageBox.Show("The Room Code needs to be a integer");
                    return null;
                }
            }
            else
            {
                MessageBox.Show("The lecturer needs a valid Room code");
                return null;
            }

            if (add)
            {
                //Test if the lecturer number is unique
                LecturerService lecturerService = new LecturerService();
                Lecturer test = lecturerService.GetLecturerById(lecturer.LecturerId);
                if (test != null)
                {
                    MessageBox.Show("There is already a lecturer with this lecturer id");
                    return null;
                }
            }

            //Test if Room exists

            RoomService roomService = new RoomService();
            Room room = roomService.GetRoomById(lecturer.RoomCode);
            if (room == null)
            {
                MessageBox.Show("The lecturer needs a valid room");
                return null;
            }

            return lecturer;
        }

        public void RefreshLecturerBox()
        {
            lecturerCB.Items.Clear();
            LecturerService lecturerService = new LecturerService();
            List<Lecturer> lecturers = lecturerService.GetLecturers();

            foreach (Lecturer lecturer in lecturers)
            {
                lecturerCB.Items.Add(lecturer);
            }
        }
        private void updateLecturerB_Click(object sender, EventArgs e)
        {
            Lecturer lecturer = GetLecturer(false);
            if (lecturer != null)
            {
                LecturerService lecturerService = new LecturerService();

                lecturerService.UpdateLecturer(lecturer);

                int auxiliary = lecturerCB.SelectedIndex;
                lecturerCB.Text = "";
                RefreshLecturerBox();
                lecturerCB.SelectedIndex = auxiliary;

            }
        }
    }
}