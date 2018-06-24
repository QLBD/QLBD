using QLBD.DTO;
using System;
using System.Collections.Generic;
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
        public static List<Player> GetPlayerByClubID(int clubID)
        {
            List<Player> listPlayer = new List<Player>();
            DataTable data = DataProvider.ExecuteQuery("select * from PLAYER where CLUBID = '" + clubID + "'");
            foreach(DataRow row in data.Rows)
            {
                Player player = new Player(row);
                listPlayer.Add(player);
            }
            return listPlayer;
        }
        public static bool AddPlayer(int playerID, int clubID, string playerName, string position, string nationality,
                DateTime birthday, float height, float weight)
        {
            string query = "ADD_PLAYER @PLAYERID , @CLUBID , @NAME , @POSITION , @NATIONALITY , @BIRTHDAY , @HEIGHT , @WEIGHT ";
            int result = DataProvider.ExecuteNonQuery(query, new object[] { playerID, clubID, playerName, position, nationality, birthday, height, weight });
            return result > 0;
        }
        public static bool UpdatePlayer(int playerID, int clubID, string playerName, string position, string nationality,
                DateTime birthday, float height, float weight)
        {
            string query = "UPDATE_PLAYER @PLAYERID , @CLUBID , @NAME , @POSITION , @NATIONALITY , @BIRTHDAY , @HEIGHT , @WEIGHT ";
            int result = DataProvider.ExecuteNonQuery(query, new object[] { playerID, clubID, playerName, position, nationality, birthday, height, weight });
            return result > 0;
        }
        public static bool DeletePlayer(int playerID)
        {
            int result = DataProvider.ExecuteNonQuery("DELETE PLAYER WHERE PLAYERID = '" + playerID + "'");
            return result > 0;
        }
    }
}
