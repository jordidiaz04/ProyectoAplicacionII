using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio
{
    [ServiceContract]
    public interface IServiceHuesped
    {
        [OperationContract]
        List<HuespedBE> contarHuespedesPorPais();

        [OperationContract]
        Boolean registrarHuesped(HuespedBE huespedBE);
    }
}

[DataContract]
[Serializable]
public class HuespedBE
{
    [DataMember]
    public Int32 Id { get; set; }
    [DataMember]
    public String IdTipoDoc { get; set; }
    [DataMember]
    public String NumDoc { get; set; }
    [DataMember]
    public String Nombre { get; set; }
    [DataMember]
    public String Email { get; set; }
    [DataMember]
    public String Telefono { get; set; }
    [DataMember]
    public String IdPais { get; set; }

    //Datos para Reportes
    [DataMember]
    public String Pais { get; set; }
    [DataMember]
    public Int32 Cantidad { get; set; }
}
