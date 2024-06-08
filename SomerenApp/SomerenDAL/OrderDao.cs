using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Data;



namespace SomerenDAL
{
    public class OrderDao : BaseDao
    {

        public void CreateOrder(Order order)
        {
            string command = "INSERT INTO buys VALUES ( @StudentNumber, @Id, @Amount, @Date)";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@Id", order.DrinkId);
            sqlParameters[1] = new SqlParameter("@StudentNumber", order.StudentNumber);
            sqlParameters[2] = new SqlParameter("@Amount", order.Amount);
            sqlParameters[3] = new SqlParameter("@Date", order.Date);

            ExecuteEditQuery(command, sqlParameters);
        }

        public List<Order> GetAllOrders()
        {
            string query = "SELECT StudentNumber, DrinkID, Amount, Date FROM buys";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public HashSet<int> GetYearOfOrders()
        {
            string query = "SELECT DISTINCT YEAR(Date) AS Year FROM buys";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);
            
            HashSet<int> years = new HashSet<int>();
            foreach (DataRow dr in dataTable.Rows)
            {
                int year = (int)dr["Year"];
                years.Add(year);
            }
            
            return years;
        }

        private List<Order> ReadTables(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Order order = new Order()
                {
                    DrinkId = (int)dr["DrinkID"],
                    StudentNumber = (int)dr["StudentNumber"],
                    Amount = (int)dr["Amount"],
                    Date = (DateTime)dr["Date"]
                };
                orders.Add(order);
            }
            return orders;
        }

        public List<Order> GetOrdersForTimePeriod(DateTime startDate, DateTime endDate)
        {
            string query = "SELECT StudentNumber, DrinkID, Amount, Date FROM buys WHERE Date BETWEEN @StartDate AND @EndDate";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@StartDate", startDate);
            sqlParameters[1] = new SqlParameter("@EndDate", endDate);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

    }
}