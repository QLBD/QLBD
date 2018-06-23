using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBD.DAO
{
    public class ClubDAO
    {
        public static DataTable GetAllListClub()
        {
            return DataProvider.ExecuteQuery("Select * from CLUB");
        }
    }
}
