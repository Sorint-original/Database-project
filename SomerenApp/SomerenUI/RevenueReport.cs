using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class RevenueReport : Form
    {
        public RevenueReport()
        {
            InitializeComponent();
        }

        private void RevenueReport()
        {
            if (dateTimePicker1 == null || dateTimePicker2 == null)
            {
                return;
            }
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            int salesAmount = OrderService.GetDrinksOrdered(startDate, endDate);
            label3.Text = salesAmount.ToString();

            decimal turnover = OrderService.CalculateRevenue(startDate, endDate);
            label4.Text = $"${turnover:0.00}";

            List<Student> students = OrderService.GetStudentsWhoOrdered(startDate, endDate);    
            foreach (Student student in students)
            {
                textBox1.Text += student.FirstName + " " + student.LastName + Environment.NewLine;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            RevenueReport();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RevenueReport();
        }
    }
}
