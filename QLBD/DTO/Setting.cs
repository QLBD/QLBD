using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBD.DTO
{
    public class Setting
    {
        public Setting(DataRow row)
        {
            MinAge = (int)row["MINAGE"];
            MaxAge = (int)row["MAXAGE"];
            MinPlayer = (int)row["MINPLAYER"];
            MaxPlayer = (int)row["MAXPLAYER"];
            MaxForeignPlayer = (int)row["MAXFOREIGNPLAYER"];
            GoalTypeKind = (int)row["GOALTYPEKIND"];
            MaxGoalTime = (int)row["MAXGOALTIME"];
            WinScore = (int)row["WINSCORE"];
            LoseScore = (int)row["LOSESCORE"];
            DrawScore = (int)row["DRAWSCORE"];
        }

        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int MinPlayer { get; set; }
        public int MaxPlayer { get; set; }
        public int MaxForeignPlayer { get; set; }
        public int GoalTypeKind { get; set; }
        public int MaxGoalTime { get; set; }
        public int WinScore { get; set; }
        public int LoseScore { get; set; }
        public int DrawScore { get; set; }
    }
}
