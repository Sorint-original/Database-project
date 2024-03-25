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
            ShowDashboardPanel();
        }

        private void ShowDashboardPanel()
        {
            // hide all other panels
            pnlActivity.Hide();
            pnlStudents.Hide();
            pnlRooms.Hide();
            pnlLecturers.Hide();
            pnlDrinks.Hide();
            // show dashboard
            pnlDashboard.Show();
        }

        private void ShowStudentsPanel()
        {
            // hide all other panels
            pnlActivity.Hide();
            pnlRooms.Hide();
            pnlLecturers.Hide();
            pnlDashboard.Hide();
            pnlDrinks.Hide();

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

            pnlActivity.Hide();
            pnlLecturers.Hide();
            pnlDrinks.Hide();


            pnlStudents.Show();
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

        private void ShowLecturersPanel()
        {
            // hide all other panels
            pnlDashboard.Hide();
            pnlActivity.Hide();
            pnlRooms.Hide();
            pnlStudents.Hide();
            pnlDrinks.Hide();

            // show lecturers 
            pnlLecturers.Show();

            try
            {
                // get and display all lecturers 
                List<Lecturer> lecturer = GetLecturers();
                DisplayLecturers(lecturer);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the students: " + e.Message);

            }
        }

        private void ShowActivityPanel()
        {
            pnlDashboard.Hide();
            pnlLecturers.Hide();
            pnlRooms.Hide();
            pnlDrinks.Hide();
            pnlStudents.Hide();

            pnlActivity.Show();
            try
            {

                List<Activity> activities = GetActivities();


                DisplayActivities(activities);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the activities: " + e.Message);
            }

        }

        private void ShowDrinksPanel()
        {
            pnlDashboard.Hide();
            pnlLecturers.Hide();
            pnlRooms.Hide();
            pnlStudents.Hide();
            pnlActivity.Hide();

            pnlDrinks.Show();


            try
            {

                List<Drink> drinks = GetDrinks();


                DisplayDrinks(drinks);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the drinks: " + e.Message);
            }

        }

        private List<Activity> GetActivities()
        {
            ActivityService activityService = new ActivityService();
            List<Activity> activities = activityService.GetActivities();
            return activities;
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

        private List<Lecturer> GetLecturers()
        {
            LecturerService lecturerService = new LecturerService();
            List<Lecturer> lecturers = lecturerService.GetLecturers();
            return lecturers;
        }

        private List<Drink> GetDrinks()
        {
            DrinkService drinkService = new DrinkService();
            List<Drink> drinks = drinkService.GetDrinks();
            return drinks;
        }

        private void DisplayLecturers(List<Lecturer> lecturers)
        {
            // clear the listview before filling it
            listViewLecturers.Items.Clear();

            foreach (Lecturer lecturer in lecturers)
            {
                ListViewItem li = new ListViewItem(lecturer.LecturerId.ToString());
                li.SubItems.Add(lecturer.FirstName);
                li.SubItems.Add(lecturer.LastName);
                li.SubItems.Add(lecturer.PhoneNumber);
                li.SubItems.Add(lecturer.Age.ToString());
                li.SubItems.Add(lecturer.RoomCode.ToString());


                li.Tag = lecturer;   // link lecturer object to listview item
                listViewLecturers.Items.Add(li);

            }
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
                listViewRooms.Items.Add(li);
            }
        }

        private void DisplayActivities(List<Activity> activities)
        {

            // clear the listview before filling it
            listViewActivity.Items.Clear();

            foreach (Activity activity in activities)
            {
                ListViewItem li = new ListViewItem(activity.id.ToString());
                li.SubItems.Add(activity.name);
                li.SubItems.Add(activity.startTime.ToString());
                li.SubItems.Add(activity.endTime.ToString());
                li.SubItems.Add(activity.day.ToString());
                li.Tag = activity;   // link student object to listview item
                listViewActivity.Items.Add(li);
            }
        }

        private void DisplayDrinks(List<Drink> drinks)
        {

            // clear the listview before filling it
            listViewDrinks.Items.Clear();
       

            foreach (Drink drink in drinks)
            {
                ListViewItem li = new ListViewItem(drink.Id.ToString());

                li.SubItems.Add(drink.Name);
                li.SubItems.Add(drink.Price.ToString());
                if (drink.Alcohol)
                {
                    li.SubItems.Add("Alcoholic");
                }
                else
                {
                    li.SubItems.Add("Non Alcoholic");
                }
                if (drink.StockAmount == 0)
                {
                    li.SubItems.Add("stock empty");
                }
                else if (drink.StockAmount < 10)
                {
                    li.SubItems.Add("stock nearly depleted");
                }
                else
                {
                    li.SubItems.Add("stock sufficient");
                }
                li.SubItems.Add(drink.AmountSold.ToString());
                li.Tag = drink;   // link student object to listview item
                listViewDrinks.Items.Add(li);
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

        private void activitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowActivityPanel();
        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLecturersPanel();
        }

        private void drinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDrinksPanel();
        }

        private void DrinkAddButton_Click(object sender, EventArgs e)
        {
            
            DrinkService drinkService = new DrinkService();
            AddDrinkForm addDrinkForm = new AddDrinkForm(true,drinkService.GetAvalibleID());
            addDrinkForm.ShowDialog();
            ShowDrinksPanel();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteForm deleteForm = new DeleteForm(GetDrinks());
            deleteForm.ShowDialog();
            ShowDrinksPanel();
        }
    }
}