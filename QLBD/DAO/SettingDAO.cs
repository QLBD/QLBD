using QLBD.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBD.DAO
{
    public class SettingDAO
    {
        public static Setting GetParameterSetting()
        {
            DataTable data = DataProvider.ExecuteQuery("select * from PARAMETER");
            return new Setting(data.Rows[0]);
        }
    }
}
