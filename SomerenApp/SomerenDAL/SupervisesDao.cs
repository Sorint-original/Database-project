
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;
namespace SomerenDAL {
    public class SupervisesDao : BaseDao {
        public List<Supervise> getSuperviseByActivityId(int activityId) {
            /* string query = "SELECT * FROM Supervises WHERE ActivityID = @activityId";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ActivityID", activityId);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters)); */
       /*      return ReadTables(ExecuteSelectQuery(query, sqlParameters)); */

            string query = "SELECT * FROM Supervises WHERE ActivityID = @activity";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@activity", activityId);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));

        }

        public void addSupervisor(int lecturerId, int activityId) {
            string query = "INSERT INTO Supervises (LectureID, ActivityID) SELECT @lecturerId, @activityId WHERE NOT EXISTS (SELECT 1 FROM Supervises WHERE LectureID = @lecturerId AND ActivityID = @activityId)";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@lecturerId", lecturerId);
            sqlParameters[1] = new SqlParameter("@activityId", activityId);

            ExecuteEditQuery(query, sqlParameters);
            
        }

        public void removeSupervisor(int activityId, int lectureId) {
            string query = "DELETE FROM Supervises WHERE ActivityID = @activityId AND LectureID = @lectureId";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@activityId", activityId);
            sqlParameters[1] = new SqlParameter("@lectureId", lectureId);
        
            ExecuteEditQuery(query, sqlParameters);
            
        }

        private List<Supervise> ReadTables(DataTable dataTable) {
            List<Supervise> supervises = new List<Supervise>();

            foreach (DataRow dr in dataTable.Rows) {
                Supervise supervise = new Supervise() {
                    lecturerID = (int)dr["LectureID"],
                    activityID = (int)dr["ActivityID"]
                };
                supervises.Add(supervise);
            }
            return supervises;
        }
    }

    
}