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
            pnlSupervisor.Hide();
            pnlActivity.Hide();
            pnlStudents.Hide();
            pnlRooms.Hide();
            pnlLecturers.Hide();
            pnlDrinks.Hide();
            pnlVAT.Hide();
            // show dashboard
            pnlDashboard.Show();
        }

        private void ShowStudentsPanel()
        {
            // hide all other panels
            pnlSupervisor.Hide();
            pnlActivity.Hide();
            pnlRooms.Hide();
            pnlLecturers.Hide();
            pnlDashboard.Hide();
            pnlDrinks.Hide();
            pnlVAT.Hide();
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
            pnlSupervisor.Hide();
            pnlLecturers.Hide();
            pnlDrinks.Hide();
            pnlVAT.Hide();

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
            pnlSupervisor.Hide();
            pnlActivity.Hide();
            pnlRooms.Hide();
            pnlStudents.Hide();
            pnlDrinks.Hide();
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
            pnlSupervisor.Hide();
            pnlLecturers.Hide();
            pnlRooms.Hide();
            pnlDrinks.Hide();
            pnlStudents.Hide();
            pnlVAT.Hide();
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
            pnlSupervisor.Hide();
            pnlDashboard.Hide();
            pnlLecturers.Hide();
            pnlRooms.Hide();
            pnlStudents.Hide();
            pnlActivity.Hide();
            pnlVAT.Hide();
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
            pnlSupervisor.Hide();
            pnlDashboard.Hide();
            pnlLecturers.Hide();
            pnlRooms.Hide();
            pnlStudents.Hide();
            pnlActivity.Hide();
            pnlDrinks.Hide();

            pnlVAT.Show();
            DisplayOrderYears();
        }

        private void ShowSupervisorsPanel()
        {
            pnlDashboard.Hide();
            pnlLecturers.Hide();
            pnlRooms.Hide();
            pnlStudents.Hide();
            pnlActivity.Hide();
            pnlDrinks.Hide();
            pnlVAT.Hide();
            pnlSupervisor.Show();

            Supervisorsinit();
        }

        private void Supervisorsinit()
        {
            LecturerService lecturerService = new LecturerService();

            ActivityService activityService = new ActivityService();

            allSupervisorsView.Items.Clear();
            List<Lecturer> supervisors = lecturerService.GetLecturers();

           

            foreach (Lecturer supervisor in supervisors)
            {
                ListViewItem li = new ListViewItem(supervisor.LecturerId.ToString());
               
                li.SubItems.Add($"{supervisor.FirstName} {supervisor.LastName}");
                li.Tag = supervisor;
                allSupervisorsView.Items.Add(li);
            }

            activityView.Items.Clear();
            List<Activity> activities = activityService.GetActivities();
            foreach (Activity activity in activities)
            {
                ListViewItem li = new ListViewItem(activity.id.ToString());
                li.SubItems.Add(activity.name);
                li.Tag = activity;
                activityView.Items.Add(li);
            }

        }

        private void displaySupervisorForActivity(int activityID)
        {

            if (activityID == null)
            {
                return;
            }

            SuperviseService superviseService = new SuperviseService();
            LecturerService lecturerService = new LecturerService();

            supervisorsView.Items.Clear();
            List<Supervise> supervises = superviseService.getSuperviseByActivityId(activityID);

            List<Lecturer> supervisors = supervises.ConvertAll(supervise => lecturerService.GetLecturerById(supervise.lecturerID));

          

            foreach (Lecturer supervisor in supervisors)
            {
                ListViewItem li = new ListViewItem(supervisor.LecturerId.ToString());
                li.SubItems.Add($"{supervisor.FirstName} {supervisor.LastName}");

                li.Tag = supervisor;
                supervisorsView.Items.Add(li);
            }

        }

        private void addSupervisor()
        {

            SuperviseService superviseService = new SuperviseService();

            if (activityView.SelectedItems.Count == 0 || allSupervisorsView.SelectedItems.Count == 0)
            {
                return;
            }

            int activityID = int.Parse(activityView.SelectedItems[0].Text);
            int supervisorID = int.Parse(allSupervisorsView.SelectedItems[0].Text);

            superviseService.AddSupervisor(activityID, supervisorID);
        }

        private void removeSupervisor()
        {


            SuperviseService superviseService = new SuperviseService();
            if (supervisorsView.SelectedItems.Count == 0)
            {
                return;
            }

            int activityID = int.Parse(activityView.SelectedItems[0].Text);
            int supervisorID = int.Parse(supervisorsView.SelectedItems[0].Text);
            superviseService.DeleteSupervisor(activityID, supervisorID);

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
            if (quarter == null || yearSelectorBox.SelectedItem == null)
            {
                return;
            }
          
            OrderService orderService = new OrderService();
            var result = orderService.CalculateVAT(quarter);
            vatLow.Text = $"${result.Item1:0.00}";
            vatHigh.Text = $"${result.Item2:0.00}";
            vatTotal.Text = $"${result.Item3:0.00}";


        }

        private Quarter? GetSelectedYearAndQuarter()
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
          /*   CalculateVAT(); */
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
            quarterStart.Text = "";
            quarterEnd.Text = "";
            if (qSelectorBox.SelectedItem != null)
            {
            Quarter quarter = GetSelectedYearAndQuarter();
            quarterStart.Text = quarter.StartDate;
            quarterEnd.Text = quarter.EndDate;
            }
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

        private void RemoveSupervisor_Click(object sender, EventArgs e)
        {
            removeSupervisor();
                  DialogResult result = MessageBox.Show(
            $"Are you sure you want to remove this supervisor?",
            "Confirm Remove",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );
        if (result == DialogResult.Yes)
         {   try
            {
                displaySupervisorForActivity(int.Parse(activityView.SelectedItems[0].Text));
            }
            catch (Exception)
            {
                return;
            }}
          

        }

        private void AddSupervisor_Click(object sender, EventArgs e)
        {
            addSupervisor();
            try
            {
                displaySupervisorForActivity(int.Parse(activityView.SelectedItems[0].Text));
            }
            catch (Exception)
            {
                return;
            }
        }

        private void activityView_SelectedIndexChanged(object sender, EventArgs e)
        {
        

         
            try { 
                   displaySupervisorForActivity(int.Parse(activityView.SelectedItems[0].Text));
            }
            catch (Exception)
            {
                return;
            }


        }

        private void supervisorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSupervisorsPanel();
        }
    }

}