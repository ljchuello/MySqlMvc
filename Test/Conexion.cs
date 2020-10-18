using System;
using MySql.Data.MySqlClient;

namespace Test
{
    public class Conexion
    {
        public static MySqlConnection Devolver()
        {
            var mySqlConnection = new MySqlConnection();
            try
            {
                mySqlConnection.ConnectionString = "datasource=127.0.0.1; port=3306; username=root; password=; database=DPSOsDbPrd;";
                mySqlConnection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return mySqlConnection;
        }
    }
}
