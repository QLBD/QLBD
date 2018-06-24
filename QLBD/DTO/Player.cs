using System;
using System.Data;
using System.Linq;

namespace QLBD.DTO
{
    public class Player
    {
        public Player(DataRow row)
        {
            PlayerID = (int)row["PLAYERID"];
            ClubID = (int)row["CLUBID"];
            Name = row["NAME"].ToString();
            Position = row["POSITION"].ToString();
            Nationality = row["NATIONALITY"].ToString();
            BirthDay = DateTime.Parse(row["BIRTHDAY"].ToString());
            Age = (int)row["AGE"];
            Height = float.Parse(row["HEIGHT"].ToString());
            Weight = float.Parse(row["WEIGHT"].ToString());
        }

        public int PlayerID { get; set; }
        public int ClubID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthDay { get; set; }
        public int Age { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
    }
}
