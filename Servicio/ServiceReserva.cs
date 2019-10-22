using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio
{
    public class ServiceReserva : IServiceReserva
    {
        public List<ReservaBE> listarReservasPorCliente(string dni)
        {
            throw new NotImplementedException();
        }
    }
}
