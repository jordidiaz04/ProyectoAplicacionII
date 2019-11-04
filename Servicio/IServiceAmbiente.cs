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
                                                           DateTime fechaFinal,
                                                           String idUbigeo);
        [OperationContract]
        List<AmbienteBE> obtenerAmbienteDisponiblePorRangoDePrecios(DateTime fechaInicio,
                                                                    DateTime fechaFinal,
                                                                    Decimal precioMenor,
                                                                    Decimal precioMayor,
                                                                    String idUbigeo);
        [OperationContract]
        List<AmbienteBE> obtenerAmbienteDisponiblePorAforo(DateTime fechaInicio,
                                                           DateTime fechaFinal,
                                                           Int32 aforoMenor,
                                                           Int32 aforoMayor,
                                                           String idUbigeo);
    }
}

[DataContract]
[Serializable]
public class AmbienteBE
{
    [DataMember]
    public String Distrito { get; set; }
    [DataMember]
    public String Direccion { get; set; }
    [DataMember]
    public Int32 Piso { get; set; }
    [DataMember]
    public String Identificador { get; set; }
    [DataMember]
    public Int32 Aforo { get; set; }
    [DataMember]
    public Decimal Precio { get; set; }
}
