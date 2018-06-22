using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBD.DTO
{
    public class Account
    {
        public Account(DataRow row)
        {
            Username = row["USERNAME"].ToString();
            DisplayName = row["DISPLAYNAME"].ToString();
            PassWord = row["PASSWORD"].ToString();
            Type = (int)row["ACCOUNTTYPE"];
        }

        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string PassWord { get; set; }
        public int Type { get; set; }
    }
}
