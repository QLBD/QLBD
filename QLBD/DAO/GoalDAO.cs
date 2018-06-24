using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBD.DAO
{
    public class GoalDAO
    {
        public static DataTable GetGoalsByMatchID(int matchID)
        {
            return DataProvider.ExecuteQuery("select * from GOAL where MATCHID = '" + matchID + "'");
        }
    }
}
