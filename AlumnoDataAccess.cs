using System.Data.SqlClient;

namespace Common
{
    public class Alumno
    {
        public int Code { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public int CodeCiudad { get; set; }
        public string Requerimiento { get; set; }
    }
    public class AlumnoDataAccess
    {
        private string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=DataStd;Integrated Security=True";

        public void GuardarAlumno(Alumno alumno)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO DataAlumnos (Code, Nombre, Apellido, Email, Sexo, CodeCiudad, Requerimiento) VALUES (@Code, @Nombre, @Apellido, @Email, @Sexo, @CodeCiudad, @Requerimiento)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Code", alumno.Code);
                    command.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                    command.Parameters.AddWithValue("@Apellido", alumno.Apellido);
                    command.Parameters.AddWithValue("@Email", alumno.Email);
                    command.Parameters.AddWithValue("@Sexo", alumno.Sexo);
                    command.Parameters.AddWithValue("@CodeCiudad", alumno.CodeCiudad);
                    command.Parameters.AddWithValue("@Requerimiento", alumno.Requerimiento);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
