using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace StoreWithDataSources.Data
{
    public class Check
    {
        public bool CheckUser(string userName, string password)
        {
            GetData getData = new GetData();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string query = $"SELECT UserName, Password FROM Users WHERE UserName = '{userName}' AND Password = '{password}'";

            SqlCommand sqlCommand = new SqlCommand(query, getData.GetSqlConnection());

            sqlDataAdapter.SelectCommand = sqlCommand;
            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckValidationUserName(string input)
        {
            string userName = input;
            Regex regex = new Regex(@"^[0-9a-zA-Z]{8,}");

            if (regex.IsMatch(userName))
            {
                return true;
            }
            else return false;
        }

        public bool CheckValidationPassword(string input)
        {
            //string password = input;
            //Regex regex = new Regex(@"(^[0-9]{1,}?,[A-Z]{1,}?,[a-z]{1,}?){8,}?");

            //if (Regex.IsMatch(password, @"(?=.*[0-9a-zA-Z]{1,})") &&
            //    Regex.IsMatch(password, @"(?=.*[a-z]{1,})") &&
            //    Regex.IsMatch(password, @"(?=.*[A-Z]{1,})") &&
            //    Regex.IsMatch(password, @"[0-9a-zA-Z]{8,}"))
            if(Regex.IsMatch(input, @"^(?=.*[0-9])(?=.*[A-Z])\w{8,}"))
            {
                return true;
            }
            else return false;
        }
    }
}
