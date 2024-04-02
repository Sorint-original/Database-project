using SomerenService;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class Participants : Form
    {
        public Participants(int activityid = 0)
        {
            InitializeComponent();
            RefreshActivityBox();
            if (activityid == 0)
            {
                //when it enters update without any drink selected
                ActivityBox.SelectedIndex = 0;
            }
            else
            {
                //when it eneters update with a drink selected
                ActivityService activityService = new ActivityService();
                List<SomerenModel.Activity> activities = activityService.GetActivities();
                for (int i = 0; i < activities.Count; i++)
                {
                    if (activityid == activities[i].id)
                    {
                        ActivityBox.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        public void RefreshStudentLists()
        {
            SomerenModel.Activity activity = ActivityBox.SelectedItem as SomerenModel.Activity;
            StudentService studentService = new StudentService();
            List<Student> students = studentService.ParticipantStudents(activity);
            AddStudentList(students, listViewPart);
            List<Student> allstudents = studentService.GetStudents();
            int j = 0, i = 0;
            while (i < allstudents.Count && j < students.Count)
            {
                if (allstudents[i].StudentNumber == students[j].StudentNumber)
                {
                    allstudents.RemoveAt(i);
                    i--;
                    j++;
                }
                i++;
            }
            AddStudentList(allstudents, listViewNonPart);


        }

        public void AddStudentList(List<Student> students, ListView listView)
        {
            listView.Items.Clear();
            foreach (Student student in students)
            {
                ListViewItem li = new ListViewItem(student.StudentNumber.ToString());
                li.SubItems.Add(student.FirstName);
                li.SubItems.Add(student.LastName);
                li.SubItems.Add(student.PhoneNumber);
                li.SubItems.Add(student.Class);
                li.Tag = student;   // link student object to listview item
                listView.Items.Add(li);
            }
        }

        public void RefreshActivityBox()
        {
            ActivityService activityService = new ActivityService();
            ActivityBox.Items.Clear();
            List<SomerenModel.Activity> activities = activityService.GetActivities();
            foreach (SomerenModel.Activity activity in activities)
            {
                ActivityBox.Items.Add(activity);
            }
        }

        private void ActivityBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshStudentLists();
        }

        private void AddStudB_Click(object sender, EventArgs e)
        {
            if(listViewNonPart.SelectedItems.Count > 0)
            {
                SomerenModel.Activity activity = ActivityBox.SelectedItem as SomerenModel.Activity;
                StudentService studentService = new StudentService();
                Student student = studentService.GetStudentById(int.Parse(listViewNonPart.SelectedItems[0].Text));
                ActivityService activityService = new ActivityService();
                activityService.AddParticipant(activity,student);
            }
            RefreshStudentLists() ;
        }

        private void RemoveStudB_Click(object sender, EventArgs e)
        {

        }
    }
}
