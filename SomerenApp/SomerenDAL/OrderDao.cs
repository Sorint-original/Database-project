using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;

namespace SomerenDAL
{
    public class OrderDao : BaseDao
    {

        public void CreateOrder(Order order)
        {
            string command = "INSERT INTO buys VALUES ( @StudentNumber, @Id, @Amount)";
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@Id", order.DrinkId);
            sqlParameters[1] = new SqlParameter("@StudentNumber", order.StudentNumber);
            sqlParameters[2] = new SqlParameter("@Amount", order.Amount);
            sqlParameters[3] = new SqlParameter("@Date", order.Date);

            ExecuteEditQuery(command, sqlParameters);
        }

    }
}
