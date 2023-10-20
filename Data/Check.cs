using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace StoreWithDataSources.Data
{
    public class Check
    {
        public bool CheckUser(string userName, string password)
        {
            object user = null;
            object pass = null;
            GetData getData = new GetData();
            HashEncryption hash = new HashEncryption();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string passwordHash = hash.GetHashPassword(password);

            string query = $"SELECT UserName, Password FROM Users WHERE UserName = '{userName}' AND Password = '{passwordHash}'";

            try
            {
                SqlCommand sqlCommand = new SqlCommand(query, getData.GetSqlConnection());
                getData.OpenConnection();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    user = sqlDataReader["UserName"];
                    pass = sqlDataReader["Password"];
                }

                sqlDataReader.Close();
                getData.CloseConnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error connection to database({ex.Message})", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if(user == null || pass == null)
            {
                return false;
            }

            if (user.ToString().Equals(userName) && pass.ToString().Equals(passwordHash))
            {
                return true;
            }
            else return false;
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
            if(Regex.IsMatch(input, @"^(?=.*[0-9])(?=.*[A-Z])\w{8,}"))
            {
                return true;
            }
            else return false;
        }
    }
}
