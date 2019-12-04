using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio
{
    [ServiceContract]
    public interface IServiceTipoDocumento
    {
        [OperationContract]
        List<TipoDocumentoBE> listarTiposDocumento();
    }
}

[DataContract]
[Serializable]
public class TipoDocumentoBE
{
    [DataMember]
    public String Id { get; set; }
    [DataMember]
    public String Descripcion { get; set; }
}