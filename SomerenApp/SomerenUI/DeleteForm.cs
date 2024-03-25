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
    public partial class DeleteForm : Form
    {
        public DeleteForm(List<Drink> drinks)
        {
            InitializeComponent();
            comboBox1.Items.Clear();    
            foreach (Drink drink in drinks)
            {
                comboBox1.Items.Add(drink);
            }

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Drink drink = comboBox1.SelectedItem as Drink;
            if (drink != null)
            {
                comboBox1 .Items.Remove(drink);
                DrinkService drinkService = new DrinkService();
                drinkService.DeleteByID(drink.Id);
            }
        }
    }
}
