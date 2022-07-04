using System;
using System.Data;
using System.Data.SqlClient;

namespace Selenium
{
    internal class Valiable
    {
        public Valiable()
        {
            Open_Connection_Data();
            SqlCMD();
            Close_Connection_Data();
        }
        private void Open_Connection_Data()
        {
            try
            {
                sqlConnection = new SqlConnection(Sql_Path);
                if (sqlConnection == null)
                {
                    sqlConnection = new SqlConnection(Sql_Path);
                }
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("error DataBase");
            }
        }
        private void Close_Connection_Data()
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        private void SqlCMD()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Accout";
            cmd.Connection = sqlConnection;
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                username[Cout_User] = sqlDataReader.GetString(0);
                password[Cout_User] = sqlDataReader.GetString(1);
                Cout_User++;
            }
        }
        public int Cout_User;
        private string[] username = new string[10];
        private string[] password = new string[10];
        private string Sql_Path = @"Data Source=DESKTOP;Initial Catalog=Data_User;Integrated Security=True";
        private SqlConnection sqlConnection = null;
        public string[] Username { get => username; }
        public string[] Password { get => password; }
        public static Random random = new Random();
    }
    internal class Sub_valiable
    {
    }
}
