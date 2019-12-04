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
        HuespedBE obtenerHuesped(String idTipoDoc,
                                 String numDoc);

        [OperationContract]
        List<HuespedReporteBE> contarHuespedesPorPais(DateTime fechaInicio,
                                                      DateTime fechaFinal);

        [OperationContract]
        List<HuespedBE> obtenerHuespedesPorPais(DateTime fechaInicio,
                                                DateTime fechaFinal,
                                                String idPais);

        [OperationContract]
        Decimal obtenerDineroGastadoPorHuesped(DateTime fechaInicio,
                                               DateTime fechaFinal,
                                               String idTipoDoc,
                                               String numDoc);

        [OperationContract]
        Boolean registrarHuesped(HuespedBE objHuespedBE);
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
    public String TipoDoc { get; set; }
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
    [DataMember]
    public String Pais { get; set; }
}

[DataContract]
[Serializable]
public class HuespedReporteBE
{
    [DataMember]
    public String Pais { get; set; }
    [DataMember]
    public Int32 Cantidad { get; set; }
}