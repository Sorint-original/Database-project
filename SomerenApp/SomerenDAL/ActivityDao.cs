

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL

{ 
    public class ActivityDao : BaseDao
    {
        public List<Activity> GetAllActivities()
        {
            string query = "SELECT ActivityID, Day, StartTime, EndTime, TypeActivity  FROM Activity";
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
                    day = (string)dr["Day"],
                    startTime = (string)(dr["StartTime"].ToString()),
                    endTime = (string)(dr["EndTime"].ToString())
                };
                activities.Add(activity);
            }
            return activities;
        }

        public void AddParticipant(Activity activity, Student student)
        {
            string query = "INSERT INTO participates VALUES (@StudentNumber,@ActivityId);";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@ActivityId", activity.id);
            sqlParameters[1] = new SqlParameter("@StudentNumber", student.StudentNumber);
            ExecuteEditQuery(query, sqlParameters);
        }

        public void RemoveParticipant(Activity activity, Student student)
        {
            string query = "DELETE participates WHERE StudentNumber = @StudentNumber AND ActivityID = @ActivityId;";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@ActivityId", activity.id);
            sqlParameters[1] = new SqlParameter("@StudentNumber", student.StudentNumber);
            ExecuteEditQuery(query, sqlParameters);
        }
    }   
}