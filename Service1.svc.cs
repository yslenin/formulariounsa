using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using Common;

namespace ProyectService
{
    public class Service1 : IService1
    {
        public void SaveFormData(string formData)
        {
            string filePath = HttpContext.Current.Server.MapPath("datos.txt");
            File.AppendAllText(filePath, formData);
        }

        public IList<string> getCiudades()
        {
            CiudadDataAccess ciudadDataAccess = new CiudadDataAccess();
            IList<string> ciudades = ciudadDataAccess.ObtenerCiudades();

            return ciudades;
        }
    }
}
