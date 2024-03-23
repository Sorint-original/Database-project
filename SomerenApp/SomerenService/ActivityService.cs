
namespace SomerenService
{
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