using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceAmbiente" en el código y en el archivo de configuración a la vez.
    public class ServiceAmbiente : IServiceAmbiente
    {
        public List<AmbienteBE> obtenerAmbienteDisponiblePorFecha(string fechaInicio, string fechaFinal)
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    List<AmbienteBE> lstAmbienteBE = new List<AmbienteBE>();

                    return lstAmbienteBE;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<AmbienteBE> obtenerAmbienteDisponiblePorPrecio(decimal precio)
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    List<AmbienteBE> lstAmbienteBE = new List<AmbienteBE>();

                    return lstAmbienteBE;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
