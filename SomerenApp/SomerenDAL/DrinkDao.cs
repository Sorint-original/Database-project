using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace SomerenDAL
{
    public class DrinkDao : BaseDao
    {
        public List<Drink> GetAllDrinks()
        {
            string query = "SELECT DrinkID, Name, Price, IfAlcoholic, StockAmount FROM Drink ORDER BY Name;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Drink> ReadTables(DataTable dataTable)
        {
            List<Drink> drinks = new List<Drink>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Drink drink = new Drink()
                {
                    Id = (int)dr["DrinkID"],
                    Name = (string)dr["Name"],
                    Price = (decimal)dr["Price"],
                    Alcohol = (bool)dr["IfAlcoholic"],
                    StockAmount = (int)dr["StockAmount"]
                };
                drinks.Add(drink);
            }
            return drinks;
        }
    }
}
