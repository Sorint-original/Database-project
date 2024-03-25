﻿using SomerenModel;
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
            string query = "SELECT DrinkID, Name, Price, IfAlcoholic, StockAmount, AmountSold FROM Drink ORDER BY Name;";
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
                    StockAmount = (int)dr["StockAmount"],
                    AmountSold = (int)dr["AmountSold"]
                };
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

        public void CreateEmptyDrink(int ID)
        {
            string command = "INSERT INTO Drink VALUES (@Id,NULL,NULL,NULL,NULL,NULL)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Id", ID);

            ExecuteEditQuery(command, sqlParameters);
        }


        public void DeleteById(int ID)
        {
            string command = "DELETE FROM Drink WHERE DrinkId = @Id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Id", ID);

            ExecuteEditQuery(command, sqlParameters);
        }

    }

}
