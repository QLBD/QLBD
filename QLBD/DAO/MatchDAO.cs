using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBD.DAO
{
    public class MatchDAO
    {
        public static DataTable GetAllListMatch(int roundID)
        {
            return DataProvider.ExecuteQuery("Select * from MATCH where ROUNDID ='"+ roundID +"'");
        }
        public static bool AddMatch(int matchID, int homeClub, int awayClub,
            int roundID, DateTime matchDay, DateTime matchTime, string stadium)
        {
            string query = "ADD_MATCH @MATCHID , @HOMECLUB , @AWAYCLUB , @ROUNDID , @MATCHDAY , @MATCHTIME , @STADIUM ";
            int result = DataProvider.ExecuteNonQuery(query, new object[] { matchID, homeClub, awayClub, roundID, matchDay, matchTime, stadium });
            return result > 0;
        }
        public static bool UpdateMatch(int matchID, int homeClub, int awayClub,
            int roundID, DateTime matchDay, DateTime matchTime, string stadium)
        {
            string query = "UPDATE_MATCH @MATCHID , @HOMECLUB , @AWAYCLUB , @ROUNDID , @MATCHDAY , @MATCHTIME ,  @STADIUM ";
            int result = DataProvider.ExecuteNonQuery(query, new object[] { matchID, homeClub, awayClub, roundID, matchDay, matchTime, stadium });
            return result > 0;
        }
        public static bool DeleteMatch(int matchID)
        {
            int result = DataProvider.ExecuteNonQuery("DELETE MATCH WHERE MATCHID = '" + matchID + "'");
            return result > 0;
        }
    }
}
