using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBD.DTO
{
    public class Match
    {
        public Match(DataRow row)
        {
            MatchID = (int)row["MATCHID"];
            HomeClub = (int)row["HOMECLUB"];
            AwayClub = (int)row["AWAYCLUB"];
            HomeScore = (int)row["HOMESCORE"];
            AwayScore = (int)row["AWAYSCORE"];
            Round = (int)row["ROUND"];
            MatchTime = DateTime.Parse(row["MATCHTIME"].ToString());
            MatchID = int.Parse(row["ISPLAYED"].ToString());
        }

        public int MatchID { get; set; }
        public int HomeClub { get; set; }
        public int AwayClub { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int Round { get; set; }
        public DateTime MatchTime { get; set; }
        public int isPlayed { get; set; }
    }
}
