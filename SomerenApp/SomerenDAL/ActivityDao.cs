namespace SomerenDAL

{ 
    public class ActivityDao : BaseDao
    {
        public List<Activity> GetAllActivities()
        {
            string query = "SELECT activity_id, activity_name, activity_date, activity_startTime, activity_endTime FROM [Activity]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Activity> ReadTables(DataTable dataTable)
        {
            List<Activity> activities = new List<Activity>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Activity activity = new Activity()
                {
                    id = (int)dr["ActivityID"],
                    name = (string)(dr["TypeActivity"].ToString()),
                    date = (DateTime)dr["Day"],
                    startTime = (string)(dr["StartTime"].ToString()),
                    endTime = (string)(dr["EndTime"].ToString())
                };
                activities.Add(activity);
            }
            return activities;
        }
    }   
}