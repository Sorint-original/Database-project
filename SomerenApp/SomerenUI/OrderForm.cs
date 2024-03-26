using SomerenModel;
using SomerenService;
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
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
            RefreshStudents(GetStudents());
            RefreshDrinks(GetDrinks());
        }

        private List<Drink> GetDrinks()
        {
            DrinkService drinkService = new DrinkService();
            List<Drink> drinks = drinkService.GetDrinks(true);
            return drinks;
        }

        private List<Student> GetStudents()
        {
            StudentService studentService = new StudentService();
            List<Student> students = studentService.GetStudents();
            return students;
        }

        private void RefreshDrinks(List<Drink> drinks)
        {
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
                li.SubItems.Add(drink.StockAmount.ToString());
                li.SubItems.Add(drink.AmountSold.ToString());
                li.Tag = drink;   // link student object to listview item
                listViewDrinks.Items.Add(li);
            }
        }

        private void RefreshStudents(List<Student> students)
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

        private void OrderB_Click(object sender, EventArgs e)
        {
            if(PriceL.Text != "")
            {

                DrinkService drinkService = new DrinkService();
                Drink drink = drinkService.GetDrinkById(int.Parse(listViewDrinks.SelectedItems[0].Text));

                if(drink.StockAmount > int.Parse(OrderAmountTB.Text))
                {
                    //Create Order
                    Order order = new Order()
                    {
                        DrinkId = int.Parse(listViewDrinks.SelectedItems[0].Text),
                        StudentNumber = int.Parse(listViewStudents.SelectedItems[0].Text),
                        Amount = int.Parse(OrderAmountTB.Text),
                        Date = DateTime.Now
                    };

                    OrderService orderService = new OrderService();
                    orderService.CreateOrder(order);

                    //Modify Stock Ammount
                    drink.StockAmount -= int.Parse(OrderAmountTB.Text);
                    drinkService.UpdateDrink(drink);

                    //Reset Everything
                    PriceL.Text = "";
                    OrderAmountTB.Text = "";
                    listViewDrinks.SelectedItems.Clear();
                    listViewStudents.SelectedItems.Clear();
                }
                else
                {
                    MessageBox.Show("The oder amount can't be over the stock amount of the drink");
                }
                
            }
            else
            {
                MessageBox.Show("You have to select a student, a drink and to enter a an amount to buy");
            }
        }

        private void OrderAmountTB_TextChanged(object sender, EventArgs e)
        {
            if(OrderAmountTB.Text != "")
            {
                try
                {
                    int aux = int.Parse(OrderAmountTB.Text);
                }
                catch
                {
                    MessageBox.Show("the amount needs to be an integer");
                    OrderAmountTB.Text = "";
                }
            }
            UpdatePrice();
        }

        private void listViewDrinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private void listViewStudents_SelectedIndexChanged(Object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private void UpdatePrice()
        {
            if (CheckCnditions())
            {
                int Amount = int.Parse(OrderAmountTB.Text);
                DrinkService drinkService = new DrinkService();
                Drink drink = drinkService.GetDrinkById(int.Parse(listViewDrinks.SelectedItems[0].Text));
                PriceL.Text = $"{drink.Price * Amount:0.00}";
            }
            else
            {
                PriceL.Text = "";
            }
        }

        private bool CheckCnditions()
        {
            if(OrderAmountTB.Text.Length > 0 && listViewDrinks.SelectedItems.Count > 0 && listViewStudents.SelectedItems.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
