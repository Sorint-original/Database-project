
using SomerenDAL;
    using SomerenModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

namespace SomerenService {
    public class SuperviseService {
        private SupervisesDao superviseDao = new SupervisesDao();

        public List<Supervise> getSuperviseByActivityId(int activityId) {
            try {
                List<Supervise> supervises = superviseDao.getSuperviseByActivityId(activityId);
                return supervises;
            } catch (Exception e) {
                throw new Exception("Someren couldn't connect to the database");
            }
        }

        public void AddSupervisor(int activityId, int lecturerId) {
            try {
             superviseDao.addSupervisor(lecturerId, activityId);
            } catch (Exception e) {
                throw new Exception("Someren couldn't connect to the database");
            }
        }

        public void DeleteSupervisor(int activityId, int lecturerId) {
            try {
              superviseDao.removeSupervisor(activityId, lecturerId);
            } catch (Exception e) {
                throw new Exception("Someren couldn't connect to the database");
            }
        }
    }
}