using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;


namespace SomerenDAL
{
    public class DrinkDao : BaseDao
    {
        public List<Drink> GetAllDrinks( bool OrderByName)
        {
            string query;
            if (OrderByName)
            {
                query = "SELECT DrinkID, Name, Price, IfAlcoholic, StockAmount, (SELECT SUM(B.Amount) FROM buys AS B WHERE B.DrinkID = D.DrinkID ) AS AmountSold FROM Drink AS D ORDER BY Name;";
            }
            else
            {
                query = "SELECT DrinkID, Name, Price, IfAlcoholic, StockAmount, (SELECT SUM(B.Amount) FROM buys AS B WHERE B.DrinkID = D.DrinkID ) AS AmountSold FROM Drink AS D FROM Drink ;";
            }
            
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public Drink GetDrinkById(int id)
        {
            string query = "SELECT DrinkID, Name, Price, IfAlcoholic, StockAmount, (SELECT SUM(B.Amount) FROM buys AS B WHERE B.DrinkID = D.DrinkID ) AS AmountSold FROM Drink AS D WHERE D.DrinkID = @Id ;";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0]=new SqlParameter("@Id", id);
            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);
            DataRow dr = dataTable.Rows[0];
            Drink drink = new Drink()
            {
                Id = (int)dr["DrinkID"],
                Name = (string)dr["Name"],
                Price = (decimal)dr["Price"],
                Alcohol = (bool)dr["IfAlcoholic"],
                StockAmount = (int)dr["StockAmount"],

            };
            try
            {
                drink.AmountSold = (int)dr["AmountSold"];
            }
            catch
            {
                drink.AmountSold = 0;
            }
            return drink;
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
                    StockAmount = (int)dr["StockAmount"],
                   
                };
                try
                {
                    drink.AmountSold = (int)dr["AmountSold"];
                }
                catch
                {
                    drink.AmountSold = 0;
                }
                
                drinks.Add(drink);
            }
            return drinks;
        }

        public List<int> GetAllID()
        {
            List<int> ids = new List<int>();
            string query = "SELECT DrinkID FROM Drink;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);
            foreach (DataRow dr in dataTable.Rows)
            {
                ids.Add((int)dr["DrinkID"]);
            }
            return ids;
        }

        public void AddDrink(Drink drink)
        {
            string command = "INSERT INTO Drink VALUES (@Id, @Name, @Price, @Alcohol, @StockAmount)";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@Id", drink.Id);
            sqlParameters[1] = new SqlParameter("@Name",drink.Name);
            sqlParameters[2] = new SqlParameter("@Price", drink.Price);
            sqlParameters[3] = new SqlParameter("@Alcohol", drink.Alcohol);
            sqlParameters[4] = new SqlParameter("@StockAmount", drink.StockAmount);

            ExecuteEditQuery(command, sqlParameters);
        }

        public void UpdateDrink(Drink drink)
        {
            string command = "UPDATE Drink SET Name =  @Name, Price = @Price, IfAlcoholic =  @Alcohol, StockAmount =  @StockAmount WHERE DrinkId = @Id;";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@Id", drink.Id);
            sqlParameters[1] = new SqlParameter("@Name", drink.Name);
            sqlParameters[2] = new SqlParameter("@Price", drink.Price);
            sqlParameters[3] = new SqlParameter("@Alcohol", drink.Alcohol);
            sqlParameters[4] = new SqlParameter("@StockAmount", drink.StockAmount);

            ExecuteEditQuery(command, sqlParameters);
        }


        public void DeleteById(int ID)
        {
            string command = "DELETE FROM buys WHERE DrinkId = @Id ; DELETE FROM Drink WHERE DrinkId = @Id;";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Id", ID);

            ExecuteEditQuery(command, sqlParameters);
        }

    }

}
