using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBD.DTO
{
    public class Goal
    {
        public Goal(DataRow row)
        {
            GoalID = (int)row["GOALID"];
            MatchID = (int)row["MATCHID"];
            ClubID = (int)row["CLUBID"];
            PlayerID = (int)row["PLAYERID"];
            GoalTypeID = (int)row["GOALTYPEID"];
            GoalTime = (int)row["GOALTIME"];
        }

        public int GoalID { get; set; }
        public int MatchID { get; set; }
        public int ClubID { get; set; }
        public int PlayerID { get; set; }
        public int GoalTypeID { get; set; }
        public int GoalTime { get; set; }
    }
}
