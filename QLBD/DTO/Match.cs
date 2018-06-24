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
            RoundID = (int)row["ROUNDID"];
            MatchDay = DateTime.Parse(row["MATCHDAY"].ToString());
            MatchTime = DateTime.Parse(row["MATCHTIME"].ToString());
            isPlayed = (bool)row["ISPLAYED"];
        }

        public int MatchID { get; set; }
        public int HomeClub { get; set; }
        public int AwayClub { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int RoundID { get; set; }
        public DateTime MatchDay { get; set; }
        public DateTime MatchTime { get; set; }
        public bool isPlayed { get; set; }
    }
}
