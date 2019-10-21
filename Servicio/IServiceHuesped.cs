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
    }
}

[DataContract]
[Serializable]
public class HuespedBE
{
    [DataMember]
    public String Pais { get; set; }
    [DataMember]
    public Int32 Cantidad { get; set; }
}
