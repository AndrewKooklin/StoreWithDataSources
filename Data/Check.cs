using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
    }
}
