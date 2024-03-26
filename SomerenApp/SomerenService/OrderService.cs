using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenService
{
    public class OrderService
    {

        private OrderDao orderDao;

        public OrderService()
        {
            orderDao = new OrderDao();
        }
        public void CreateOrder(Order order)
        {
            orderDao.CreateOrder(order);
        }
    }
}
