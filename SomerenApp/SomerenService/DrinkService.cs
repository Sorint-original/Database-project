using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenService
{
    public class DrinkService
    {
        private DrinkDao drinkDao;

        public DrinkService()
        {
            drinkDao = new DrinkDao();
        }

        public List<Drink> GetDrinks(bool OrderByName)
        {
            List<Drink> drinks = drinkDao.GetAllDrinks( OrderByName);
            return drinks;
        }


        public int GetAvalibleID()
        {
            List<int> ids = drinkDao.GetAllID();
            for(int i = 1; i <= ids.Count(); i++)
            {
                if (i != ids[i-1])
                {
                    return i;
                }
            }
            return ids.Count()+1;
        }

        public void DeleteByID(int id)
        {
            drinkDao.DeleteById(id);
        }

        public void AddDrink(Drink drink)
        {
            drinkDao.AddDrink(drink);
        }

        public void UpdateDrink(Drink drink)
        {
            drinkDao.UpdateDrink(drink);
        }
    }
}
