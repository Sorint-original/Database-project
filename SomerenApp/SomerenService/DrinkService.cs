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

        public List<Drink> GetDrinks()
        {
            List<Drink> drinks = drinkDao.GetAllDrinks();
            return drinks;
        }

        public void AddEmptyDrink()
        {
            int id = GetAvalibleID();
            drinkDao.CreateEmptyDrink(id);
        }

        private int GetAvalibleID()
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
    }
}
