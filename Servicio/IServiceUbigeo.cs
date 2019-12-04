using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio
{
    [ServiceContract]
    public interface IServiceUbigeo
    {
        [OperationContract]
        List<PaisBE> obtenerPaises();

        [OperationContract]
        List<DepartamentoBE> obtenerDepartamentos();

        [OperationContract]
        List<ProvinciaBE> obtenerProvincias(String idDepartamento);

        [OperationContract]
        List<DistritoBE> obtenerDistritos(String idDepartamento,
                                          String idProvincia);
    }
}

[DataContract]
[Serializable]
public class PaisBE
{
    [DataMember]
    public String IdPais { get; set; }

    [DataMember]
    public String Pais { get; set; }
}

[DataContract]
[Serializable]
public class DepartamentoBE
{
    [DataMember]
    public String IdDepartamento { get; set; }

    [DataMember]
    public String Departamento { get; set; }
}

[DataContract]
[Serializable]
public class ProvinciaBE
{
    [DataMember]
    public String IdProvincia { get; set; }

    [DataMember]
    public String Provincia { get; set; }
}

[DataContract]
[Serializable]
public class DistritoBE
{
    [DataMember]
    public String IdDistrito { get; set; }

    [DataMember]
    public String Distrito { get; set; }
}