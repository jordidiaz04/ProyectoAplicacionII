using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio
{
    [ServiceContract]
    public interface IServiceTipoPago
    {
        [OperationContract]
        List<TipoPagoBE> obtenerTiposPago();
    }
}

[DataContract]
[Serializable]
public class TipoPagoBE
{
    [DataMember]
    public Int32 Id { get; set; }
    [DataMember]
    public String Descripcion { get; set; }
}