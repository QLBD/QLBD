using QLBD.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBD.DAO
{
    public class RoundDAO
    {
        public static List<Round> GetAllListRound()
        {
            List<Round> listRound = new List<Round>();
            DataTable data = DataProvider.ExecuteQuery("select * from ROUND");
            foreach(DataRow row in data.Rows)
            {
                Round round = new Round(row);
                listRound.Add(round);
            }
            return listRound;
        }
    }
}
