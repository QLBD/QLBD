using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBD.DTO
{
    public class Club
    {

        public Club(DataRow row)
        {
            ClubID = (int)row["CLUBID"];
            ClubShortName = row["CLUBSHORTNAME"].ToString();
            ClubName = row["CLUBNAME"].ToString();
            EstablishedYear = (int)row["ESTABLISHEDYEAR"];
            HomeField = row["HOMEFIELD"].ToString();
        }

        public int ClubID { get; set; }
        public string ClubShortName { get; set; }
        public string ClubName { get; set; }
        public int EstablishedYear { get; set; }
        public string HomeField { get; set; }
    }
}
