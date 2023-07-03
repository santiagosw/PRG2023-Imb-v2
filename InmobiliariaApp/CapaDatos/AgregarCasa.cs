using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class AdminisCasa : Conexion
    {
        private string server = "localhost";
        private string database = "inmobiliaria_itsc";
        private string user = "root";
        private string password = "root";

        private string cadenaConexion;

        public AdminisCasa()
        {
            cadenaConexion = $"Server={server};Database={database};User Id={user};Password={password};";
        }

        public int abmAgregarCasa(string accion, Casa casa)
        {
            int filasAfectadas = 0;

            using (MySqlConnection connection = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand();
                    command.Connection = connection;

                    if (accion == "Agregar")
                    {
                        command.CommandText = "INSERT INTO Casa (Direccion, Precio, Disponible, FechaConstruccion) VALUES (@Direccion, @Precio, @Disponible, @FechaConstruccion)";
                        command.Parameters.AddWithValue("@Direccion", casa.Direccion);
                        command.Parameters.AddWithValue("@Precio", casa.Precio);
                        command.Parameters.AddWithValue("@Disponible", casa.Disponible);
                        command.Parameters.AddWithValue("@FechaConstruccion", casa.FechaConstruccion);
                    }

                    filasAfectadas = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }
            }

            return filasAfectadas;
        }
    }
}