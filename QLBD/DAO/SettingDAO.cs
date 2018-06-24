using QLBD.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBD.DAO
{
    public class SettingDAO
    {
        public static Setting GetParameterSetting()
        {
            DataTable data = DataProvider.ExecuteQuery("select * from PARAMETER");
            return new Setting(data.Rows[0]);
        }
        public static bool UpdateParameterSetting(int MinAge, int MaxAge, int MinPlayer, int MaxPlayer, int MaxForeignPlayer, int MaxGoalTime, int WinScore, int LoseScore, int DrawScore)
        {
            string query = "UPDATE_PARAMETER @MINAGE , @MAXAGE , @MINPLAYER , @MAXPLAYER , @MAXFOREIGNPLAYER , @MAXGOALTIME , @WINSCORE , @LOSESCORE , @DRAWSCORE ";
            int result = DataProvider.ExecuteNonQuery(query, new object[] { MinAge, MaxAge, MinPlayer, MaxPlayer, MaxForeignPlayer, MaxGoalTime, WinScore, LoseScore, DrawScore });
            return result > 0;
        }
    }
}
