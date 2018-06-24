﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBD.DTO
{
    public class Round
    {
        public Round(DataRow row)
        {
            RoundID = (int)row["ROUNDID"];
            RoundName = row["ROUNDNAME"].ToString();
        }

        public int RoundID { get; set; }
        public string RoundName { get; set; }
    }
}
