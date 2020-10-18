using System;
using System.Data;
using System.Threading.Tasks;
using System.Web.UI;
using MySql.Data.MySqlClient;
using Test.Modelo;

namespace Test.Controlador
{
    public class CoUsuarios
    {
        public async Task<MoUsuarios> Select_EmailAsync(Page page, string email)
        {
            return await Task.Run(() =>
            {
                MoUsuarios moUsuarios = new MoUsuarios();
                try
                {
                    using (MySqlConnection mySqlConnection = Conexion.Devolver())
                    {
                        MySqlCommand mySqlCommand = new MySqlCommand();
                        mySqlCommand.Connection = mySqlConnection;
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.CommandText = "SELECT * FROM `usuarios` WHERE `Email` = @Email;";
                        mySqlCommand.Parameters.AddWithValue("@Email", email);
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                moUsuarios = Maker(mySqlDataReader);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return moUsuarios;
            });
        }

        private MoUsuarios Maker(MySqlDataReader dReader)
        {
            try
            {
                MoUsuarios moUsuarios = new MoUsuarios();
                moUsuarios.Id = dReader.IsDBNull(dReader.GetOrdinal("Id")) ? string.Empty : dReader.GetString(dReader.GetOrdinal("Id"));
                moUsuarios.NumeroTelefono = dReader.IsDBNull(dReader.GetOrdinal("NumeroTelefono")) ? string.Empty : dReader.GetString(dReader.GetOrdinal("NumeroTelefono"));
                return moUsuarios;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new MoUsuarios();
            }
        }
    }
}
