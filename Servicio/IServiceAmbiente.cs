using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio
{
    [ServiceContract]
    public interface IServiceAmbiente
    {
        [OperationContract]
        List<AmbienteBE> obtenerAmbienteDisponiblePorFecha(String fechaInicio, String fechaFinal);
        List<AmbienteBE> obtenerAmbienteDisponiblePorPrecio(Decimal precio);
    }
}

[DataContract]
[Serializable]
public class AmbienteBE
{
    [DataMember]
    public String direccion { get; set; }
    [DataMember]
    public Int32 piso { get; set; }
    [DataMember]
    public String identificador { get; set; }
    [DataMember]
    public Decimal precio { get; set; }
}
