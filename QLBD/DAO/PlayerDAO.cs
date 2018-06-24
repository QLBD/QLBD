using System;
using System.Data;
using System.Linq;

namespace QLBD.DAO
{
    public class PlayerDAO
    {
        public static DataTable GetAllListPlayer()
        {
            return DataProvider.ExecuteQuery("Select PLAYERID, CLUBID, NAME, POSITION, NATIONALITY, cast(BIRTHDAY as date) as BIRTHDAY, " +
                "AGE, HEIGHT, WEIGHT from PLAYER");
        }
        public static int TotalPlayerClub(int clubID)
        {
            int result = 0;
            string query = "select count(*) from PLAYER where CLUBID = '" + clubID + "'";
            result = (int)DataProvider.ExecuteScalar(query);
            return result;
        }
        public static bool AddPlayer(int playerID, int clubID, string playerName, string position, string nationality,
                DateTime birthday, int age, float height, float weight)
        {
            string query = "ADD_PLAYER @PLAYERID , @CLUBID , @NAME , @POSITION , @NATIONALITY , @BIRTHDAY , @AGE , @HEIGHT , @WEIGHT ";
            int result = DataProvider.ExecuteNonQuery(query, new object[] { playerID, clubID, playerName, position, nationality, birthday, age, height, weight });
            return result > 0;
        }
        public static bool UpdatePlayer(int playerID, int clubID, string playerName, string position, string nationality,
                DateTime birthday, int age, float height, float weight)
        {
            string query = "UPDATE_PLAYER @PLAYERID , @CLUBID , @NAME , @POSITION , @NATIONALITY , @BIRTHDAY , @AGE , @HEIGHT , @WEIGHT ";
            int result = DataProvider.ExecuteNonQuery(query, new object[] { playerID, clubID, playerName, position, nationality, birthday, age, height, weight });
            return result > 0;
        }
        public static bool DeletePlayer(int playerID)
        {
            int result = DataProvider.ExecuteNonQuery("DELETE PLAYER WHERE PLAYERID = '" + playerID + "'");
            return result > 0;
        }
    }
}
