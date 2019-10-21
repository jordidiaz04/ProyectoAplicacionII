using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio
{
    [ServiceContract]
    public interface IServicioHuesped
    {
        [OperationContract]
        List<HuespedBE> contarHuespedPorPais();
    }

    [DataContract]
    [Serializable]
    public class HuespedBE
    {
        [DataMember]
        public String pais { get; set; }
        [DataMember]
        public Int32 cantidad { get; set; }
    }
}
