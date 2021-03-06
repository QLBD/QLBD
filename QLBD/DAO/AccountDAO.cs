﻿using QLBD.DTO;
using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace QLBD.DAO
{
    class AccountDAO
    {
        private AccountDAO() { }

        private static string PasswordEncryption(string password)
        {
            //tính năng bảo mật cho việc đăng nhập
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);//chuyển qua mảng kiểu byte từ một chuỗi
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            //tạo ra bảng has(bảng băm) chứa các mảng byte
            //từ mật khẩu được mã hóa thành mảng băm

            string hasPass = "";

            foreach (byte item in hasData)
            {
                hasPass += item;
            }

            //tính năng mã hóa nâng cao bằng việc đảo ngược mật khẩu
            char[] arr = hasPass.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public static int Login(string userName, string passWord)
        {
            string pass = PasswordEncryption(passWord);

            string query = "USP_Login @userName , @passWord";
            DataTable result = DataProvider.ExecuteQuery(query, new object[] { userName, pass });

            if (result == null)
                return -1;
            else if (result.Rows.Count > 0)
                return 1;
            else
                return 0;

        }


        public static Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.ExecuteQuery("Select * from ACCOUNT where USERNAME = '" + userName + "'");

            foreach (DataRow row in data.Rows)
            {
                return new Account(row);
            }

            return null;
        }
    }
}

