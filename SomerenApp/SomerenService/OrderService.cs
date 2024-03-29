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
        private DrinkDao drinkDao;

        private StudentDao studentDao;
        public OrderService()
        {
            orderDao = new OrderDao();
            drinkDao = new DrinkDao();
            studentDao = new StudentDao();
        }
        public void CreateOrder(Order order)
        {
            orderDao.CreateOrder(order);
        }

        public List<Order> GetOrders()
        {
            try
            {
                List<Order> orders = orderDao.GetAllOrders();
                return orders;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public HashSet<int> GetYearOfOrders()
        {
            try
            {
                HashSet<int> year = orderDao.GetYearOfOrders();
                return year;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Order> GetOrdersForQuarter(Quarter quarter)
        {

            string format = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact(quarter.StartDate, format, null);
            DateTime endDate = DateTime.ParseExact(quarter.EndDate, format, null);
            try
            {



                List<Order> orders = orderDao.GetOrdersForTimePeriod(startDate, endDate);
                return orders;
            }
            catch (Exception e)
            {
                throw e;
            }

        }



        public (decimal lowVAT, decimal highVAT, decimal totalVAT) CalculateVAT(Quarter quarter)
        {
            List<Order> orders = GetOrdersForQuarter(quarter);
            decimal lowVAT = 0;
            decimal highVAT = 0;
            decimal totalVAT = 0;
            foreach (Order order in orders)
            {
                Drink drink = drinkDao.GetDrinkById(order.DrinkId);
                if (drink.Alcohol)
                {
                    highVAT += (order.Amount * drink.Price) * 0.21m;
                }
                else
                {
                    lowVAT += (order.Amount * drink.Price) * 0.06m;
                }


            }
            totalVAT += lowVAT + highVAT;
            return (lowVAT, highVAT, totalVAT);


        }
        public decimal CalculateRevenue(DateTime startTime, DateTime endTime)
        {
            decimal revenue = 0m;
            List<Order> orders = orderDao.GetOrdersForTimePeriod(startTime, endTime);
            foreach (Order order in orders)
            {
                Drink drink = drinkDao.GetDrinkById(order.DrinkId);
                revenue += order.Amount * drink.Price;


            }
            return revenue;
        }

        public HashSet<Student> GetStudentsWhoOrdered(DateTime startTime, DateTime endTime)
        {
            List<Order> orders = orderDao.GetOrdersForTimePeriod(startTime, endTime);
            HashSet<Student> students = new HashSet<Student>();
            foreach (Order order in orders)
            {
                students.Add(studentDao.GetStudentById(order.StudentNumber));
            }
            return students;

        }

        public int GetDrinksOrdered(DateTime startTime, DateTime endTime)
        {
            List<Order> orders = orderDao.GetOrdersForTimePeriod(startTime, endTime);
            HashSet<Drink> drinks = new HashSet<Drink>();
            foreach (Order order in orders)
            {
                drinks.Add(drinkDao.GetDrinkById(order.DrinkId));
            }
            return drinks.Count;
        }
    }
}