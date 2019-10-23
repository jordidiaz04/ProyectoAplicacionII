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
        List<AmbienteBE> obtenerAmbienteDisponiblePorFecha(DateTime fechaInicio, 
                                                           DateTime fechaFinal);
        [OperationContract]
        List<AmbienteBE> obtenerAmbienteDisponiblePorRangoDePrecios(DateTime fechaInicio,
                                                                    DateTime fechaFinal,
                                                                    Decimal precioMenor,
                                                                    Decimal precioMayor);
        [OperationContract]
        List<AmbienteBE> obtenerAmbienteDisponiblePorAforo(DateTime fechaInicio,
                                                            DateTime fechaFinal,
                                                            Int32 aforoMenor,
                                                            Int32 aforoMayor);
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
    public Int32 aforo { get; set; }
    [DataMember]
    public Decimal precio { get; set; }
}
