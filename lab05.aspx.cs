using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Laboratorio_05.ServiceReference1;

namespace Laboratorio_05
{
    public partial class lab05 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                addDropDownCiudadItems();
            }
        }
 
        protected void addDropDownCiudadItems()
        {
            CiudadDataAccess ciudadDataAccess = new CiudadDataAccess();
            IList<string> ciudades = ciudadDataAccess.ObtenerCiudades().ToList();

            ciudad.Items.AddRange(ciudades.OrderBy(c => c).Select(c => new ListItem(c)).ToArray());
        }

        protected void ButtonEnviar_Click(object sender, EventArgs e)
        {
            string nombre = this.nombre.Text;
            string apellido = this.apellido.Text;
            string sexo = sexoList.SelectedValue;
            string email = this.email.Text;
            string direccion = this.direccion.Text;
            string ciudad = this.ciudad.SelectedValue;
            string requerimiento = this.requerimiento.Text;

            string mensaje = $"\tDATOS DEL USUARIO\n" +
                $"Nombre: {nombre}\n" +
                $"Apellido: {apellido}\n" +
                $"Sexo: {sexo}\n" +
                $"Email: {email}\n" +
                $"Dirección: {direccion}\n" +
                $"Ciudad: {ciudad}\n" +
                $"Requerimiento: {requerimiento}\n";

            int code = ObtenerNuevoCode();
            int codeCiudad = ObtenerCodeCiudad(this.ciudad.SelectedValue);

            Alumno alumno = new Alumno
            {
                Code = code,
                Nombre = nombre,
                Apellido = apellido,
                Email = email,
                Sexo = sexo,
                CodeCiudad = codeCiudad,
                Requerimiento = requerimiento
            };

            AlumnoDataAccess alumnoDataAccess = new AlumnoDataAccess();
            alumnoDataAccess.GuardarAlumno(alumno);

            datosRegistro.Text = mensaje;
            datosRegistro.Style["display"] = "block";
            LimpiarFormulario();
        }

        protected int ObtenerNuevoCode()
        {
            int nuevoCode = 0;
            string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=DataStd;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ISNULL(MAX(Code), 0) FROM DataAlumnos";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        nuevoCode = Convert.ToInt32(result) + 1;
                    }
                }
            }

            return nuevoCode;
        }

        private int ObtenerCodeCiudad(string ciudadSeleccionada)
        {
            Dictionary<int, string> ciudades = new Dictionary<int, string>
            {
                { 1, "Amazonas" },
                { 2, "Ancahs" },
                { 3, "Apurimac" },
                { 4, "Arequipa" },
                { 5, "Ayacucho" },
                { 6, "Cajamarca" },
                { 7, "Callao" },
                { 8, "Cusco" },
                { 9, "Huancavelica" },
                { 10, "Huanuco" },
                { 11, "Ica" },
                { 12, "Junín" },
                { 13, "La libertad" },
                { 14, "Lambayeque" },
                { 15, "Lima" },
                { 16, "Loreto" },
                { 17, "Madre de Dios" },
                { 18, "Moquegua" },
                { 19, "Pasco" },
                { 20, "Piura" },
                { 21, "Puno" },
                { 22, "San Martín" },
                { 23, "Tacna" },
                { 24, "Tumbes" },
                { 25, "Ucayali" }
            };

            int codeCiudad = ciudades.FirstOrDefault(x => x.Value == ciudadSeleccionada).Key;

            return codeCiudad;
        }

        private void LimpiarFormulario()
        {
            this.nombre.Text = string.Empty;
            this.apellido.Text = string.Empty;
            sexoList.ClearSelection();
            this.email.Text = string.Empty;
            this.direccion.Text = string.Empty;
            this.ciudad.ClearSelection();
            this.requerimiento.Text = string.Empty;
        }
    }
}