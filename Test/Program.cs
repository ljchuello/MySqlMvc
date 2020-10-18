using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.UI;
using MySql.Data.MySqlClient;
using Test.Controlador;

namespace Test
{
    class Program
    {
        static int tarea = 100000000;
        static void Main(string[] args)
        {
            try
            {
                MainAsync().Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static async Task MainAsync()
        {
            int iteracion = 39700000;
            DateTime a = DateTime.Now;

            while (iteracion <= tarea)
            {
                List<Task> list = new List<Task>();

                for (int i = 1; i <= 50; i++)
                {
                    list.Add(LlenarAsync(++iteracion));
                }

                Task.WaitAll(list.ToArray());
            }

            DateTime b = DateTime.Now;

            Console.WriteLine($"AH demorado = {(b - a).TotalMinutes} minutos");
            Console.ReadLine();
        }

        static async Task LlenarAsync(int i)
        {
            await Task.Run(() =>
            {
                DateTime uno = DateTime.Now;
                try
                {
                    using (MySqlConnection mySqlConnection = Conexion.Devolver())
                    {
                        MySqlCommand mySqlCommand = new MySqlCommand();
                        mySqlCommand.Connection = mySqlConnection;
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.CommandText = "INSERT INTO `Usuario` (" +
                                               "\n`Id`," +
                                               "\n`Correo`," +
                                               "\n`Contrasenia`," +
                                               "\n`Nombre`," +
                                               "\n`Apellido`," +
                                               "\n`NroTlf`," +
                                               "\n`Tipo`," +
                                               "\n`IdRol`," +
                                               "\n`Idioma`," +
                                               "\n`Estatus`," +
                                               "\n`IdEmpresa`," +
                                               "\n`CtrlIdUsuario`," +
                                               "\n`CtrlDireccionIp`," +
                                               "\n`CtrlDireccionWeb`," +
                                               "\n`CtrlCreado`," +
                                               "\n`CtrlModificado`" +
                                               "\n) VALUES(" +
                                               $"\n'{i}'," +
                                               $"\n'ljchuello{i}@gmail.com'," +
                                               $"\n'{i}ab1a199cfdf1b2ec27e8bf1e5e8cf579f0a0327e'," +
                                               $"\n'Leonardo{i}'," +
                                               $"\n'Chuello{i}'," +
                                               $"\n'{i:d13}'," +
                                               $"\n'1'," +
                                               $"\n'e75cfb44-3e15-45e0-a1ce-17a5814525df'," +
                                               $"\n'2'," +
                                               $"\n'1'," +
                                               $"\n'7d9e5135-86da-4b57-ab94-2919df8270a2'," +
                                               $"\n'{i}'," +
                                               $"\n'200.200.200.200'," +
                                               $"\n'https://www.google.com/'," +
                                               $"\n'{DateTime.Now.AddMinutes(-i):yyyy-MM-dd HH:mm:ss}'," +
                                               $"\n'{DateTime.Now.AddMinutes(-i):yyyy-MM-dd HH:mm:ss}');";
                        mySqlCommand.ExecuteReader();

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                DateTime dateTimedos = DateTime.Now;
                Console.WriteLine($"{i:n2} de {tarea:n2} - {(dateTimedos-uno).TotalMilliseconds:n2}");
            });
        }
    }
}
