using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SomerenModel;
using SomerenService;

namespace SomerenUI
{
    public partial class RevenueReport : Form
    {
        public RevenueReport()
        {
            InitializeComponent();
        }

        private void Revenue()
        {
            if (dateTimePicker1 == null || dateTimePicker2 == null)
            {
                return;
            }
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            OrderService orderService = new OrderService(); 

            int salesAmount = orderService.GetDrinksOrdered(startDate, endDate);
            label3.Text = salesAmount.ToString();

            decimal turnover = orderService.CalculateRevenue(startDate, endDate);
            label4.Text = $"${turnover:0.00}";

            HashSet<Student> students = orderService.GetStudentsWhoOrdered(startDate, endDate);    
            foreach (Student student in students)
            {
                textBox1.Text += student.ToString();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            Revenue();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Revenue();
        }
    }
}
