using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio
{
    [ServiceContract]
    public interface IServiceReserva
    {
        [OperationContract]
        List<ReservaBE> listarReservasPorCliente(String dni);
    }
}

[DataContract]
[Serializable]
public class ReservaBE
{
    [DataMember]
    public String Dni { get; set; }
    [DataMember]
    public String Cliente { get; set; }
    [DataMember]
    public DateTime FechaInicio { get; set; }
    [DataMember]
    public DateTime FechaFinal { get; set; }
    [DataMember]
    public String Direccion { get; set; }
    [DataMember]
    public Int32 Piso { get; set; }
    [DataMember]
    public String Identificador { get; set; }
}
