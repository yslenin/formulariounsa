using System.Collections.Generic;
 // Importa el espacio de nombres de ProyectDatos

namespace Common
{
    public class CiudadDataAccess
    {
        private ConexionData conexionData;

        public CiudadDataAccess()
        {
            conexionData = new ConexionData();
        }

        public IList<string> ObtenerCiudades()
        {
            return conexionData.ObtenerCiudades();
        }
    }
}
