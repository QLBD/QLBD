using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBD.DAO
{
    public class PlayerDAO
    {
        public static DataTable GetAllListPlayer()
        {
            return DataProvider.ExecuteQuery("Select * from PLAYER");
        }
    }
}
