using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ProyectService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        IList<string> getCiudades();

        [OperationContract]
        void SaveFormData(string formData);
    }
}
