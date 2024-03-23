
namespace SomerenService
{
    using SomerenDAL;
    using SomerenModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ActivityService
    {
        private ActivityDao activityDao;

        public ActivityService()
        {
            activityDao = new ActivityDao();
        }

        public List<Activity> GetActivities()
        {
            List<Activity> activities = activityDao.GetAllActivities();
            return activities;
        }
    }
}