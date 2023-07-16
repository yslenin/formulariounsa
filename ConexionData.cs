using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Common
{
    public class ConexionData
    {
        private string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=DataStd;Integrated Security=True";

        public IList<string> ObtenerCiudades()
        {
            List<string> ciudades = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Ciudad FROM DataCiudad";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string ciudad = reader["Ciudad"].ToString();
                            ciudades.Add(ciudad);
                        }
                    }
                }
            }

            return ciudades;
        }

        public int ObtenerNuevoCode()
        {
            int ultimoCode = ObtenerUltimoCodeDesdeTabla();
            int nuevoCode = ultimoCode + 1;
            return nuevoCode;
        }

        private int ObtenerUltimoCodeDesdeTabla()
        {
            int ultimoCode = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MAX(Code) AS UltimoCode FROM DataAlumnos";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() && reader["UltimoCode"] != DBNull.Value)
                        {
                            ultimoCode = Convert.ToInt32(reader["UltimoCode"]);
                        }
                    }
                }
            }

            return ultimoCode;
        }
    }
}
