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
    public partial class AddDrinkForm : Form
    {
        public AddDrinkForm(bool Add, int id = 0)
        {
            InitializeComponent();
            if (Add)
            {
                SetupAdd(id);
            }
            else
            {
                SetupUpdate(id);
            }
        }

        public void SetupAdd(int id)
        {
            IdLabel.Text = id.ToString();
            UpdateB.Hide();
            pnlIdselect.Hide();
        }

        public void SetupUpdate(int id)
        {
            this.Text = "Update Drink";
            AddButton.Hide();
            RefreshIdCB();
            if(id == 0)
            {
                //when it enters update without any drink selected
                IdCB.SelectedIndex = 0;
            }
            else
            {
                //when it eneters update with a drink selected
                DrinkService drinkService = new DrinkService();
                List<Drink> drinks = drinkService.GetDrinks(false);
                for (int i = 0; i < drinks.Count; i++)
                {
                    if(id == drinks[i].Id)
                    {
                        IdCB.SelectedIndex = i;
                        break;
                    }
                }
            }

        }

        public void RefreshIdCB()
        {
            IdCB.Items.Clear();
            DrinkService drinkService = new DrinkService();
            List<Drink> drinks = drinkService.GetDrinks(false);

            foreach (Drink drink in drinks)
            {
                IdCB.Items.Add(drink);
            }
        }


        private void AddButton_Click(object sender, EventArgs e)
        {
            Drink drink = GetDrink(true);
            if (drink != null)
            {
                DrinkService drinkService = new DrinkService();
                drinkService.AddDrink(drink);
                this.Close();
            }


        }

        private Drink GetDrink(bool Add)
        {
            Drink drink = new Drink();
            if(Add)
            {
                drink.Id = int.Parse(IdLabel.Text);
            }
            else
            {
                Drink originalDrink = IdCB.SelectedItem as Drink;
                drink.Id = originalDrink.Id;
            }
            if (NameTB.Text != "")
            {
                drink.Name = NameTB.Text;
            }
            else
            {
                MessageBox.Show("The drink needs to have a name");
                return null;
            }

            if (PriceTB.Text != "")
            {
                try
                {
                    drink.Price = decimal.Parse(PriceTB.Text);
                }
                catch
                {
                    MessageBox.Show("The price of the drink has to be decimal");
                    return null;
                }
            }
            else
            {
                MessageBox.Show("The drink needs to have a price");
                return null;
            }

            if (RBTrue.Checked)
            {
                drink.Alcohol = true;
            }
            else if (RBFalse.Checked)
            {
                drink.Alcohol = false;
            }
            else
            {
                MessageBox.Show("The drink need to have specified if it is alcoholic");
                return null;
            }

            if (StockTB.Text != "")
            {
                try
                {
                    drink.StockAmount = int.Parse(StockTB.Text);
                }
                catch
                {
                    MessageBox.Show("The Stock Amount of the drink has to be an integer");
                    return null;
                }
            }
            else
            {
                MessageBox.Show("The drink needs to have a Stock amount");
                return null;
            }
            drink.AmountSold = 0;
            return drink;
        }

        private void IdCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Drink drink = IdCB.SelectedItem as Drink;
            NameTB.Text = drink.Name;
            PriceTB.Text = drink.Price.ToString();
            if (drink.Alcohol)
            {
                RBTrue.Checked = true;
                RBFalse.Checked = false;
            }
            else
            {
                RBTrue.Checked = false;
                RBFalse.Checked = true;
            }
            StockTB.Text = drink.StockAmount.ToString();
        }

        private void UpdateB_Click(object sender, EventArgs e)
        {
            Drink drink = GetDrink(false);
            if (drink != null)
            {
                DrinkService drinkService = new DrinkService();
                drinkService.UpdateDrink(drink);
          
                int auxiliary = IdCB.SelectedIndex;
                IdCB.Text = "";
                RefreshIdCB();
                IdCB.SelectedIndex = auxiliary;

            }
        }
    }
}
