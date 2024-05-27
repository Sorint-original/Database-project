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
            pnlVAT.Hide();
            pnlSupervisors.Hide();
            // show dashboard
            pnlDashboard.Show();
        }


        private void ShowAcitvitySupervisorsPanel()
        {
            // hide all other panels
            pnlActivity.Hide();
            pnlStudents.Hide();
            pnlRooms.Hide();
            pnlLecturers.Hide();
            pnlDrinks.Hide();
            pnlVAT.Hide();
            pnlDashboard.Hide();


            pnlSupervisors.Show();
            initializeSupervisorsPanel();
        }

        private void initializeSupervisorsPanel()
        {
            // clear the listview before filling it
            activityBox.Items.Clear();
            allSupervisors.Items.Clear();
            currentSupervisors.Items.Clear();

            // get and display all activities
            ActivityService activityService = new ActivityService();
            List<Activity> activities = activityService.GetActivities();
            foreach (Activity activity in activities)
            {
                ListViewItem li = new ListViewItem(activity.id.ToString());
                li.SubItems.Add(activity.name);
              
                li.Tag = activity;   // link activity object to listview item
                activityBox.Items.Add(li);
            }

            // get and display all supervisors
            LecturerService lecturerService = new LecturerService();
            List<Lecturer> lecturers = lecturerService.GetLecturers();
            foreach (Lecturer lecturer in lecturers)
            {
                ListViewItem li = new ListViewItem(lecturer.LecturerId.ToString());
                li.SubItems.Add(lecturer.FirstName);
                li.SubItems.Add(lecturer.LastName);
               
                li.Tag = lecturer;   // link lecturer object to listview item
                allSupervisors.Items.Add(li);
            }
        }



        private void updateSupervisorsForActivity()
        {
            // clear the listview before filling it
            currentSupervisors.Items.Clear();
            allSupervisors.Items.Clear();



            int activityId = int.Parse(activityBox.SelectedItems[0].Text);
            SuperviseService supervisesService = new SuperviseService();
            List<Lecturer> supervisors = supervisesService.getSupervisorsForActivity(activityId);
            foreach (Lecturer supervisor in supervisors)
            {
                ListViewItem li = new ListViewItem(supervisor.LecturerId.ToString());
                li.SubItems.Add(supervisor.FirstName);
                li.SubItems.Add(supervisor.LastName);
              
                li.Tag = supervisor;   // link lecturer object to listview item
                currentSupervisors.Items.Add(li);
            }
        }


        private void removeSupervisorFromActivity()
        {
            int activityId = int.Parse(activityBox.SelectedItems[0].Text);
            int supervisorId = int.Parse(currentSupervisors.SelectedItems[0].Text);
            SuperviseService supervisesService = new SuperviseService();
            supervisesService.DeleteSupervisor(activityId, supervisorId);
        }

        private void addSupervisorToActivity()
        {
            int activityId = int.Parse(activityBox.SelectedItems[0].Text);
            int supervisorId = int.Parse(allSupervisors.SelectedItems[0].Text);
            SuperviseService supervisesService = new SuperviseService();
            supervisesService.AddSupervisor(activityId, supervisorId);
        }

        private void ShowStudentsPanel()
        {
            // hide all other panels
            pnlActivity.Hide();
            pnlRooms.Hide();
            pnlLecturers.Hide();
            pnlDashboard.Hide();
            pnlDrinks.Hide();
            pnlVAT.Hide();
            pnlSupervisors.Hide();
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
            pnlVAT.Hide();
            pnlDashboard.Hide();
            pnlSupervisors.Hide();
            pnlStudents.Hide();
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
            pnlSupervisors.Hide();
            pnlVAT.Hide();
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
            pnlVAT.Hide();
            pnlSupervisors.Hide();
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
            pnlVAT.Hide();
            pnlSupervisors.Hide();
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


        private void ShowVATPanel()
        {
            pnlDashboard.Hide();
            pnlLecturers.Hide();
            pnlRooms.Hide();
            pnlStudents.Hide();
            pnlActivity.Hide();
            pnlDrinks.Hide();
            pnlSupervisors.Hide();

            pnlVAT.Show();
            DisplayOrderYears();
        }

        private void DisplayOrderYears()
        {
            yearSelectorBox.Items.Clear();
            OrderService orderService = new OrderService();
            HashSet<int> years = orderService.GetYearOfOrders();
            foreach (int year in years)
            {
                yearSelectorBox.Items.Add(year);
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
            List<Drink> drinks = drinkService.GetDrinks(true);
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
                li.SubItems.Add($"${drink.Price:0.00}");
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

        private void CalculateVAT()
        {
            Quarter quarter = GetSelectedYearAndQuarter();
            if (quarter == null)
            {
                return;
            }

            OrderService orderService = new OrderService();
            var result = orderService.CalculateVAT(quarter);
            vatLow.Text = $"${result.Item1:0.00}";
            vatHigh.Text = $"${result.Item2:0.00}";
            vatTotal.Text = $"${result.Item3:0.00}";


        }

        private Quarter GetSelectedYearAndQuarter()
        {
            if (yearSelectorBox.SelectedItem == null || qSelectorBox.SelectedItem == null)
            {
                return null;
            }

            String selectedYear = yearSelectorBox.SelectedItem.ToString();
            String selectedQuarter = qSelectorBox.SelectedItem.ToString();

            Quarter quarter = Quarter.GetQuarter(selectedQuarter, selectedYear);

            return quarter;
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
            AddDrinkForm addDrinkForm = new AddDrinkForm(true, drinkService.GetAvalibleID());
            addDrinkForm.ShowDialog();
            ShowDrinksPanel();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DrinkService drinkService = new DrinkService();
            while (listViewDrinks.SelectedItems.Count > 0)
            {
                drinkService.DeleteByID(int.Parse(listViewDrinks.SelectedItems[0].Text));
                listViewDrinks.Items.Remove(listViewDrinks.SelectedItems[0]);
            }

            ShowDrinksPanel();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            AddDrinkForm addDrinkForm;
            if (listViewDrinks.SelectedItems.Count > 0)
            {
                addDrinkForm = new AddDrinkForm(false, int.Parse(listViewDrinks.SelectedItems[0].Text));
            }
            else
            {
                addDrinkForm = new AddDrinkForm(false);
            }
            addDrinkForm.ShowDialog();
            ShowDrinksPanel();
        }

        private void MakeOrderB_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            orderForm.ShowDialog();
            ShowDrinksPanel();
        }

        private void vATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowVATPanel();
        }

        private void calcVatButton_Click(object sender, EventArgs e)
        {
            CalculateVAT();
        }

        private void qSelectorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            vatHigh.Text = "";
            vatLow.Text = "";
            vatTotal.Text = "";
            Quarter quarter = GetSelectedYearAndQuarter();
            quarterStart.Text = quarter.StartDate;
            quarterEnd.Text = quarter.EndDate;
            CalculateVAT();
        }

        private void yearSelectorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            vatHigh.Text = "";
            vatLow.Text = "";
            vatTotal.Text = "";
            if (qSelectorBox.SelectedItem == null)
            {
                return;
            }
            Quarter quarter = GetSelectedYearAndQuarter();
            quarterStart.Text = quarter.StartDate;
            quarterEnd.Text = quarter.EndDate;
            CalculateVAT();

        }

        private void RevenueB_Click(object sender, EventArgs e)
        {
            RevenueReport revenueReport = new RevenueReport();
            revenueReport.ShowDialog();

        }

        private void DeleteStudentB_Click(object sender, EventArgs e)
        {
            //Message box warning + validation
            if (listViewStudents.SelectedItems.Count > 0)
            {
                string message = "Do you want to Delete this student?";
                string title = "Delete student";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    DeleteStudents();
                }
            }
        }

        private void DeleteStudents()
        {
            StudentService studentService = new StudentService();
            while (listViewStudents.SelectedItems.Count > 0)
            {
                studentService.DeleteByID(int.Parse(listViewStudents.SelectedItems[0].Text));
                listViewStudents.Items.Remove(listViewStudents.SelectedItems[0]);
            }

            ShowStudentsPanel();
        }

        private void AddStudentB_Click(object sender, EventArgs e)
        {
            AddStudent addStudentForm = new AddStudent(true);
            addStudentForm.ShowDialog();
            ShowStudentsPanel();
        }

        private void UpdateStudentB_Click(object sender, EventArgs e)
        {
            AddStudent addStudentForm;
            if (listViewStudents.SelectedItems.Count > 0)
            {
                addStudentForm = new AddStudent(false, int.Parse(listViewStudents.SelectedItems[0].Text));
            }
            else
            {
                addStudentForm = new AddStudent(false);
            }
            addStudentForm.ShowDialog();
            ShowStudentsPanel();
        }

        private void ParticipantsB_Click(object sender, EventArgs e)
        {
            Participants ParticipantsForm;
            if (listViewActivity.SelectedItems.Count > 0)
            {
                ParticipantsForm = new Participants(int.Parse(listViewActivity.SelectedItems[0].Text));
            }
            else
            {
                ParticipantsForm = new Participants();
            }

            ParticipantsForm.ShowDialog();
        }

        private void addLectureB_Click(object sender, EventArgs e)
        {
            AddLecturer addLecturerForm = new AddLecturer(true);
            addLecturerForm.ShowDialog();
            ShowLecturersPanel();
        }

        private void updateLecturerB_Click(object sender, EventArgs e)
        {
            AddLecturer addLecturerForm;
            if (listViewLecturers.SelectedItems.Count > 0)
            {
                addLecturerForm = new AddLecturer(false, int.Parse(listViewLecturers.SelectedItems[0].Text));
            }
            else
            {
                addLecturerForm = new AddLecturer(false);
            }
            addLecturerForm.ShowDialog();
            ShowLecturersPanel();
        }

        private void deleteLectureB_Click(object sender, EventArgs e)
        {
            //Message box warning + validation
            if (listViewLecturers.SelectedItems.Count > 0)
            {
                string message = "Do you want to Delete this lecturer?";
                string title = "Delete lecturer";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    DeleteLecturers();
                }
            }
        }
        private void DeleteLecturers()
        {
            LecturerService lecturerService = new LecturerService();
            while (listViewLecturers.SelectedItems.Count > 0)
            {
                lecturerService.DeleteByID(int.Parse(listViewLecturers.SelectedItems[0].Text));
                listViewLecturers.Items.Remove(listViewLecturers.SelectedItems[0]);
            }

            ShowLecturersPanel();
        }

        private void removeSupervisor_Click(object sender, EventArgs e)
        {
            removeSupervisorFromActivity();


        }

        private void addSupervisor_Click(object sender, EventArgs e)
        {
            addSupervisorToActivity();

        }

        private void activityBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateSupervisorsForActivity();

        }

        private void activitySupervisorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAcitvitySupervisorsPanel();
        }
    }
}