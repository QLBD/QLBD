using QLBD.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBD.DAO
{
    public class GoalTypeDAO
    {
        public static List<GoalType> GetAllListGoalType()
        {
            List<GoalType> listGoalType = new List<GoalType>();
            DataTable data = DataProvider.ExecuteQuery("select * from GOALTYPE");
            foreach(DataRow row in data.Rows)
            {
                GoalType type = new GoalType(row);
                listGoalType.Add(type);
            }
            return listGoalType;
        }
    }
}
