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
            return DataProvider.ExecuteQuery("select * from GOAL where MATCHID = '" + matchID + "' order by GOALTIME");
        }
        public static bool AddGoal(int goalID, int matchID, int clubID, int playerID, int goalTypeID, int goalTime)
        {
            string query = "ADD_GOAL @MATCHID , @CLUBID , @PLAYERID , @GOALTYPEID , @GOALTIME ";
            int result = DataProvider.ExecuteNonQuery(query, new object[] { goalID, matchID, clubID, playerID, goalTypeID, goalTime });
            return result > 0;
        }
        public static bool UpdateGoal(int goalID, int matchID, int clubID, int playerID, int goalTypeID, int goalTime)
        {
            string query = "UPDATE_GOAL @GOALID , @MATCHID , @CLUBID , @PLAYERID , @GOALTYPEID , @GOALTIME ";
            int result = DataProvider.ExecuteNonQuery(query, new object[] { goalID, matchID, clubID, playerID, goalTypeID, goalTime });
            return result > 0;
        }
        public static bool DeleteGoal(int goalID)
        {
            int result = DataProvider.ExecuteNonQuery("DELETE GOAL WHERE GOAL = '" + goalID + "'");
            return result > 0;
        }
        public static int GetTotalGoalPlayerByPlayerID(int playerID)
        {
            int result = (int)DataProvider.ExecuteScalar("SLGHIBAN @PLAYERID", new object[] { playerID });
            return result;
        }
    }

}
