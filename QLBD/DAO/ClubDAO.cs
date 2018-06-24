using QLBD.DTO;
using System;
using System.Data;
using System.Linq;

namespace QLBD.DAO
{
    public class ClubDAO
    {
        public static DataTable GetAllListClub()
        {
            return DataProvider.ExecuteQuery("Select * from CLUB");
        }
        public static Club GetClubByID(int clubID)
        {
            string query = "select * from CLUB where CLUBID ='" + clubID + "'";
            DataTable data = DataProvider.ExecuteQuery(query);
            Club club = new Club(data.Rows[0]);
            return club;
        }
        public static Club GetClubByName(string clubName)
        {
            string query = "select * from CLUB where CLUBNAME ='" + clubName + "'";
            DataTable data = DataProvider.ExecuteQuery(query);
            Club club = new Club(data.Rows[0]);
            return club;
        }
        public static bool AddClub(int clubID, string clubName, string shortName, int establishedYear, string homeField)
        {
            string query = "ADD_CLUB @clubid , @clubname , @clubshortname , @establishedyear , @homefield ";
            int result = DataProvider.ExecuteNonQuery(query, new object[] { clubID, clubName, shortName, establishedYear, homeField });
            return result > 0;
        }
        public static bool UpdateClub(int clubID, string clubName, string shortName, int establishedYear, string homeField)
        {
            string query = "UPDATE_CLUB @clubid , @clubname , @clubshortname , @establishedyear , @homefield ";
            int result = DataProvider.ExecuteNonQuery(query, new object[] { clubID, clubName, shortName, establishedYear, homeField });
            return result > 0;
        }
        public static bool DeleteClub(int clubID)
        {
            int result = DataProvider.ExecuteNonQuery("DELETE CLUB WHERE CLUBID = '" + clubID + "'");
            return result > 0;
        }
    }
}
