using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBD.DTO
{
    public class GoalType
    {
        public GoalType(DataRow row)
        {
            GoalTypeID = (int)row["GOALTYPEID"];
            GoalTypeName = row["GOALTYPENAME"].ToString();
        }

        public int GoalTypeID { get; set; }
        public string GoalTypeName { get; set; }
    }
}
